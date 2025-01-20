using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordData : MonoBehaviour
{
    public static RecordData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    public const int recordNum = 9;
    public const string NAME = "RecordData";

    public string[] recordName = new string[recordNum];
    public int lastID;

    class SaveData
    {
        public string[] recordName = new string[recordNum];
        public int lastID;
    }

   SaveData ForSave()
    {
        var saveData = new SaveData();

        for(int i = 0; i < recordNum; i++)
        {
            saveData.recordName[i] = recordName[i];
        }
        saveData.lastID = lastID;

        return saveData;
    }
    void ForLoad(SaveData saveData)
    {
        lastID = saveData.lastID;
        for(int i = 0;i < recordNum; i++)
        {
            recordName[i] = saveData.recordName[i];
        }
    }
    
    public void Save()
    {
        SaveSystem.SaveByPlayerPrefs(NAME,ForSave());
    }

    public void Load()
    {
        if(PlayerPrefs.HasKey(NAME))
        {
            string json = SaveSystem.LoadFromPlayerPrefs(NAME);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            ForLoad(saveData);
        }
    }
    

}
