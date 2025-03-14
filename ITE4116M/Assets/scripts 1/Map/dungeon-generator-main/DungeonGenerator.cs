using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public static DungeonGenerator Instance;

    [Header("Debug Info")]
    [SerializeField] private int deadEndCount = 0; // 序列化以便在Inspector查看
    [Header("Special Room Settings")]
    [Range(0f, 1f)] public float specialRoomChance = 0.7f; // 死路生成特殊房間機率


    private void Awake()
    {
        Instance = this;
        PlayerPrefab = Resources.Load("testCharacter") as GameObject;
        PlayerPrefab = Object.Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity, DungeonManager);
    }

    public void Init()
    {
        SetCamera();
    }
    public void SetCamera()
    {
        VirtualCamera = GameObject.Find("Virtual Camera");
        cameraBinder = VirtualCamera.GetComponent<CameraTargetBinder>();
        cameraBinder.BindCameraToPlayer(PlayerPrefab);
    }
    public enum RoomType
    {
        Normal,          // 普通房間
        Boss,           // Boss房間
        Treasure,      // ?箱房
        Shop,           // 商店
        Spawn,          // 初始房間
        Enemy

    }
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
        public bool isExplored;
        public bool isDeadEnd = false; // 死路標?
    }

    [System.Serializable]
    public class RoomRule
    {
        public GameObject prefab;
        public Vector2Int minPosition;
        public Vector2Int maxPosition;
        [Range(1, 100)] public int spawnWeight = 50; // 生成權重
        public RoomType roomType;
        public bool spawnOnlyAtDeadEnd; // 僅在死路生成

    }
    

    public GameObject PlayerPrefab;
    public Transform DungeonManager;
    public Vector2Int size;
    public int startPos = 0;
    public RoomRule[] roomRules;
    public Vector2 offset;
    bool isPlayer = false;
    [SerializeField] private CameraTargetBinder cameraBinder;
    [SerializeField] private GameObject VirtualCamera;

    public List<Cell> board;

    void Start()
    {
        MazeGenerator();
        SetCamera();
        isPlayer = true;
        ForceDeadEnd();

    }

    public Transform getPlayer()
    {
        GameObject player = PlayerPrefab;
        return player.transform;
    }


    RoomRule FindRule(RoomType targetType)
    {
        foreach (RoomRule rule in roomRules)
        {
            if (rule.roomType == targetType)
            {
                return rule;
            }
        }
        return null; // 如果沒有找到對應?型的?則
    }
    void GenerateDungeon()
    {
        MarkDeadEnds(); // 先標?所有死路
        // 后处理：如果没有死路则强制生成
        if (deadEndCount == 0)
        {
            float dynamicChance = Mathf.Clamp(1f - (deadEndCount * 0.2f), 0.3f, 0.8f);
            specialRoomChance = dynamicChance;  
            ForceDeadEnd();
            MarkDeadEnds(); // 重新统计
        }
        // 獲取 Boss 房間的配置
        RoomRule bossRule = FindRule(RoomType.Boss);

        // 獲取初始房間的配置
        RoomRule spawnRule = FindRule(RoomType.Spawn);

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                int index = i + j * size.x;
                Cell currentCell = board[index];

                if (!currentCell.visited) continue;

                // ?制生成初始房間
                if (i == 0 && j == 0)
                {
                    if (spawnRule != null) SpawnRoom(spawnRule, i, j);
                    continue;
                }

                // ?制生成Boss房間
                if (i == size.x - 1 && j == size.y - 1)
                {
                    if (bossRule != null) SpawnRoom(bossRule, i, j);
                    continue;
                }

                // 死路生成??
                if (currentCell.isDeadEnd && Random.value < specialRoomChance)
                {
                    List<RoomRule> deadEndRules = GetDeadEndValidRules(i, j);
                    if (deadEndRules.Count > 0)
                    {
                        SpawnRoom(SelectRoomByWeight(deadEndRules), i, j);
                        continue;
                    }
                }

                // 普通房間生成
                List<RoomRule> validRules = GetValidRules(i, j, currentCell);
                if (validRules.Count > 0)
                {
                    SpawnRoom(SelectRoomByWeight(validRules), i, j);
                }
            }
        }
    }

    void MarkDeadEnds()
    {
        deadEndCount = 0;

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Cell cell = board[i + j * size.x];

                // 新增：排除特殊房间位置
                bool isSpawn = (i == 0 && j == 0);
                bool isBoss = (i == size.x - 1 && j == size.y - 1);
                if (isSpawn || isBoss) continue;

                int openCount = 0;
                foreach (bool status in cell.status)
                {
                    if (status) openCount++;
                }

                cell.isDeadEnd = openCount == 1;
                if (cell.isDeadEnd) deadEndCount++;
            }
        }
    }

    List<RoomRule> GetDeadEndValidRules(int x, int y)
    {
        List<RoomRule> valid = new List<RoomRule>();
        foreach (RoomRule rule in roomRules)
        {
            if ((rule.roomType == RoomType.Treasure || rule.roomType == RoomType.Shop) &&
                rule.spawnOnlyAtDeadEnd &&
                IsInRange(rule, x, y))
            {
                valid.Add(rule);
            }
        }
        return valid;
    }

    List<RoomRule> GetValidRules(int x, int y, Cell cell)
    {
        List<RoomRule> valid = new List<RoomRule>();
        foreach (RoomRule rule in roomRules)
        {
            if (rule.roomType == RoomType.Spawn ||
                rule.roomType == RoomType.Boss ||
                rule.spawnOnlyAtDeadEnd) // 排除僅限死路的?則
                continue;

            if (IsInRange(rule, x, y))
            {
                valid.Add(rule);
            }
        }
        return valid;
    }

    bool IsInRange(RoomRule rule, int x, int y)
    {
        return x >= rule.minPosition.x && x <= rule.maxPosition.x &&
               y >= rule.minPosition.y && y <= rule.maxPosition.y;
    }
    RoomRule SelectRoomByWeight(List<RoomRule> validRooms)
    {
        if (validRooms.Count == 0) return null;

        int totalWeight = 0;
        foreach (RoomRule rule in validRooms)
        {
            totalWeight += rule.spawnWeight;
        }

        int randomValue = Random.Range(0, totalWeight);
        int accumulated = 0;

        foreach (RoomRule rule in validRooms)
        {
            accumulated += rule.spawnWeight;
            if (randomValue < accumulated)
            {
                return rule;
            }
        }

        return validRooms[0];
    }

    void SpawnRoom(RoomRule rule, int x, int y)
    {
        var newRoom = Instantiate(rule.prefab,
            new Vector3(x * offset.x, 0, -y * offset.y),
            Quaternion.identity,
            transform).GetComponent<RoomBehaviour>();

        newRoom.UpdateRoom(board[(x + y * size.x)].status);
        newRoom.name = $"{rule.roomType} Room ({x},{y})";
        board[x + y * size.x].isExplored = false;
    }
    void ForceDeadEnd()
    {
        // 在迷宫边缘随机选择一个单元格
        int x = Random.Range(0, size.x);
        int y = (Random.value > 0.5f) ? 0 : size.y - 1;

        // 封闭其他出口
        Cell forcedDeadEnd = board[x + y * size.x];
        for (int i = 0; i < 4; i++)
        {
            forcedDeadEnd.status[i] = (i == 0); // 只保留一个出口
        }
        forcedDeadEnd.isDeadEnd = true;
    }

    void MazeGenerator()
    {
        board = new List<Cell>();
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
                if (j == 0 && i == 0 && !isPlayer)
                {

                }
            }
        }

        int currentCell = startPos;

        Stack<int> path = new Stack<int>();

        int k = 0;

        while (k < 1000)
        {
            k++;

            board[currentCell].visited = true;

            if (currentCell == board.Count - 1)
            {
                break;
            }

            //Check the cell's neighbors
            List<int> neighbors = CheckNeighbors(currentCell);

            if (neighbors.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);

                int newCell = neighbors[Random.Range(0, neighbors.Count)];

                if (newCell > currentCell)
                {
                    //down or right
                    if (newCell - 1 == currentCell)
                    {
                        board[currentCell].status[2] = true;
                        currentCell = newCell;
                        board[currentCell].status[3] = true;
                    }
                    else
                    {
                        board[currentCell].status[1] = true;
                        currentCell = newCell;
                        board[currentCell].status[0] = true;
                    }
                }
                else
                {
                    //up or left
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
                    }
                    else
                    {
                        board[currentCell].status[0] = true;
                        currentCell = newCell;
                        board[currentCell].status[1] = true;
                    }
                }

            }

        }
        GenerateDungeon();
    }

    List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        //check up neighbor
        if (cell - size.x >= 0 && !board[(cell - size.x)].visited)
        {
            neighbors.Add((cell - size.x));
        }

        //check down neighbor
        if (cell + size.x < board.Count && !board[(cell + size.x)].visited)
        {
            neighbors.Add((cell + size.x));
        }

        //check right neighbor
        if ((cell + 1) % size.x != 0 && !board[(cell + 1)].visited)
        {
            neighbors.Add((cell + 1));
        }

        //check left neighbor
        if (cell % size.x != 0 && !board[(cell - 1)].visited)
        {
            neighbors.Add((cell - 1));
        }

        return neighbors;
    }
}