using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savedata : MonoBehaviour
{
    public static Savedata Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance!=null) 
        {
            Destroy(gameObject);
        }
    }

    public string scensName;
    public float gameTime;
   
    public class SaveData
    {
        public string scensName;
        public float gameTime;
    }

    SaveData ForSave()
    {
        var saveData = new SaveData();
        saveData.scensName = scensName;
        saveData.gameTime = gameTime;
        
        return saveData;
    }
    void ForLoad(SaveData saveData)
    {
        scensName = saveData.scensName;
        gameTime = saveData.gameTime;

    }

    public void Save(int id) 
    {
        SaveSystem.JSONSave(RecordData.Instance.recordName[id], ForSave());
    }
    public void Load(int id) 
    {
        var saveData = SaveSystem.JSONLoad<SaveData>(RecordData.Instance.recordName[id]);
        ForLoad(saveData);
    }

    public SaveData ReadForShow(int id)
    {
        return SaveSystem.JSONLoad<SaveData>(RecordData.Instance.recordName[id]);
    }

    public void Delete(int id)
    {
        SaveSystem.JSONDelete(RecordData.Instance.recordName[id]);
    }
}
