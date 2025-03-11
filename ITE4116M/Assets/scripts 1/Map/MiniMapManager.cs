using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using static DungeonGenerator;

public class MiniMapManager : MonoBehaviour
{
    [Header("UI Settings")]
    public Canvas miniMapCanvas;
    public GameObject roomIconPrefab;
    public Vector2 iconSize = new Vector2(30, 30);
    public Color exploredColor = Color.white;
    public Color unexploredColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);

    [Header("Icons")]
    public Sprite unknownRoomSprite;
    public Sprite normalRoomSprite;
    public Sprite bossRoomSprite;
    public Sprite shopRoomSprite;
    public Sprite treasureRoomSprite;
    public Sprite spawnRoomSprite;

    private Dictionary<Vector2Int, Image> roomIcons = new Dictionary<Vector2Int, Image>();
    public Transform playerTransform;
    // 获取地牢生成器引用
    public DungeonGenerator dungeonGenerator;

    void Start()
    {
        InitializeMiniMap();
    }

    public void InitializeMiniMap()
    {
        // 获取玩家引用
        playerTransform = dungeonGenerator.getPlayer();
        CreateMiniMapIcons(dungeonGenerator);
    }

    void CreateMiniMapIcons(DungeonGenerator generator)
    {
        for (int x = 0; x < generator.size.x; x++)
        {
            for (int y = 0; y < generator.size.y; y++)
            {
                Vector2Int gridPos = new Vector2Int(x, y);
                GameObject icon = Instantiate(roomIconPrefab, miniMapCanvas.transform);
                icon.GetComponent<RectTransform>().anchoredPosition =
                    new Vector2(x * iconSize.x, -y * iconSize.y);

                Image img = icon.GetComponent<Image>();
                img.sprite = unknownRoomSprite;
                img.color = unexploredColor;

                roomIcons.Add(gridPos, img);
            }
        }
    }

    void Update()
    {
        UpdateExploredRooms();
        UpdatePlayerIcon();
    }

    void UpdateExploredRooms()
    {
        DungeonGenerator generator = FindObjectOfType<DungeonGenerator>();
        Vector2Int playerGridPos = GetCurrentGridPosition();

        // 更新当前房间和相邻房间
        foreach (Vector2Int pos in GetSurroundingPositions(playerGridPos))
        {
            if (roomIcons.ContainsKey(pos))
            {
                Image icon = roomIcons[pos];
                icon.color = exploredColor;

                // 获取实际房间类型
                Cell cell = generator.board[pos.x + pos.y * generator.size.x];
                if (cell.visited) UpdateRoomIcon(icon, pos);
            }
        }
    }

    void UpdateRoomIcon(Image icon, Vector2Int pos)
    {
        DungeonGenerator generator = FindObjectOfType<DungeonGenerator>();
        int index = pos.x + pos.y * generator.size.x;

        // 获取房间实际类型（根据你的房间生成逻辑调整）
        if (pos == Vector2Int.zero)
        {
            icon.sprite = spawnRoomSprite;
        }
        else if (pos == new Vector2Int(generator.size.x - 1, generator.size.y - 1))
        {
            icon.sprite = bossRoomSprite;
        }
        else
        {
            // 这里需要根据实际房间类型判断，可扩展
            icon.sprite = normalRoomSprite;
        }
    }

    Vector2Int GetCurrentGridPosition()
    {
        DungeonGenerator generator = FindObjectOfType<DungeonGenerator>();
        Vector3 playerPos = playerTransform.position;
        int x = Mathf.RoundToInt(playerPos.x / generator.offset.x);
        int y = Mathf.RoundToInt(-playerPos.z / generator.offset.y);
        return new Vector2Int(x, y);
    }

    List<Vector2Int> GetSurroundingPositions(Vector2Int center)
    {
        List<Vector2Int> positions = new List<Vector2Int>
        {
            center,
            center + Vector2Int.up,
            center + Vector2Int.down,
            center + Vector2Int.left,
            center + Vector2Int.right
        };
        return positions;
    }

    void UpdatePlayerIcon()
    {
        // 实现玩家位置指示器（需要单独预制体）
        // 根据GetCurrentGridPosition()更新位置
    }
}