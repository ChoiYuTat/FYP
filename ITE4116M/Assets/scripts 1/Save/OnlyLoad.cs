using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class OnlyLoad : MonoBehaviour
{
    public Transform grid;
    public GameObject recordPrefab;

    public GameObject detail;
    public Image screenShot;
    public Text gameTime;
    public Text sceneName;
    public Text level;

    public static System.Action<int> OnLoad;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < RecordData.recordNum; i++) 
        {
            GameObject obj = Instantiate(recordPrefab,grid);
            if (RecordData.Instance.recordName[i]!="")
             obj.GetComponent<RecordDataUI>().SetName(i);
        }

        RecordDataUI.OnLeftClick += LeftClickGrid;
        RecordDataUI.OnEnter += ShowDetails;
        RecordDataUI.OnExit += HideDetails;
    }

    private void OnDestroy()
    {
        RecordDataUI.OnLeftClick -= LeftClickGrid;
        RecordDataUI.OnEnter -= ShowDetails;
        RecordDataUI.OnExit -= HideDetails;
    }

    void ShowDetails(int i)
    {
        var data = Savedata.Instance.ReadForShow(i);
        screenShot.sprite = SaveSystem.LoadShot(i);

        gameTime.text = $"Game Time{TimeManager.GetFormatTime((int)data.gameTime)}";
        sceneName.text = $"Scene {data.scensName}";
        level.text = $"Level {data.level}";

        detail.SetActive(true);
    }

    void HideDetails()
    {
        detail.SetActive(false);
    }

    void LeftClickGrid(int gridID)
    {
        if (RecordData.Instance.recordName[gridID] == "")
            return;
        else
        {
            if (OnLoad != null)
                OnLoad(gridID);
        }
    }

}
