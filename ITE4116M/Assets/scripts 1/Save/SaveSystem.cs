using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem
{
    static string GetPath(string fileName)
    {
        return Path.Combine(Application.persistentDataPath, fileName);
    }
    public static void SaveByPlayerPrefs(string key, object data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }
    public static string LoadFromPlayerPrefs(string key)
    {
        return PlayerPrefs.GetString(key, null);
    }

    public static void JSONSave(string fileName, object data)
    {
        string json = JsonUtility.ToJson((object)data);
        File.WriteAllText(GetPath(fileName), json);
 
        Debug.Log($"Save{GetPath(fileName)}");

    }
}