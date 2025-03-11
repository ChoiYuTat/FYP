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
    // ��ȡ��������������
    public DungeonGenerator dungeonGenerator;

    void Start()
    {
        InitializeMiniMap();
    }

    public void InitializeMiniMap()
    {
        // ��ȡ�������
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

        // ���µ�ǰ��������ڷ���
        foreach (Vector2Int pos in GetSurroundingPositions(playerGridPos))
        {
            if (roomIcons.ContainsKey(pos))
            {
                Image icon = roomIcons[pos];
                icon.color = exploredColor;

                // ��ȡʵ�ʷ�������
                Cell cell = generator.board[pos.x + pos.y * generator.size.x];
                if (cell.visited) UpdateRoomIcon(icon, pos);
            }
        }
    }

    void UpdateRoomIcon(Image icon, Vector2Int pos)
    {
        DungeonGenerator generator = FindObjectOfType<DungeonGenerator>();
        int index = pos.x + pos.y * generator.size.x;

        // ��ȡ����ʵ�����ͣ�������ķ��������߼�������
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
            // ������Ҫ����ʵ�ʷ��������жϣ�����չ
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
        // ʵ�����λ��ָʾ������Ҫ����Ԥ���壩
        // ����GetCurrentGridPosition()����λ��
    }
}