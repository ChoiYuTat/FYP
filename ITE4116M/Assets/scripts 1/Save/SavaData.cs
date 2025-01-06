using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavaData : MonoBehaviour
{
    public static SavaData Instance;

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

    SavaData ForSave()
    {
        var saveData = new SavaData();
        saveData.scensName = scensName;
        saveData.gameTime = gameTime;
        
        return saveData;
    }
    void ForLoad(SavaData savaData)
    {
        scensName = savaData.scensName;
        gameTime = savaData.gameTime;

    }

    public void Save(int id) 
    {

    }
    public void Load(int id) { }
}
