using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class SaveSystem
{
    
    static string GetPath(string fileName)
    {
        return Path.Combine(Application.persistentDataPath, fileName);
    }
    #region PlayerPrefs
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
    #endregion
    #region JSON
    public static void JSONSave(string fileName, object data)
    {
        string json = JsonUtility.ToJson((object)data);
        File.WriteAllText(GetPath(fileName), json);
#if UNITY_EDITOR
        Debug.Log($"Save{GetPath(fileName)}");
#endif
    }

    public static T JSONLoad<T>(string fileName)
    {
        string path = GetPath(fileName);

        if(File.Exists(path))
        {
            string json= File.ReadAllText(GetPath(fileName));
            var data = JsonUtility.FromJson<T>(json);
            Debug.Log($"Load{path}");
            return data;
        }
        else
        {
            return default;
        }
    }

    public static void JSONDelete(string fileName) 
    {
        File.Delete(GetPath(fileName));
    }

    public static string FindAuto()
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            FileInfo[] fileInfos = new DirectoryInfo(Application.persistentDataPath).GetFiles("*");
            for (int i = 0; i < fileInfos.Length; i++)
            {
                if (fileInfos[i].Name.EndsWith(".auto"))
                {
                    return fileInfos[i].Name;
                }
            }
        }
        return "";
    }
    #endregion

    #region DeleteAll
    #if UNITY_EDITOR
    [UnityEditor.MenuItem("Delete/Records List")]
    #endif
    public static void DeleteRecord() 
    {
        UnityEngine.PlayerPrefs.DeleteAll();
        Debug.Log("Delete All List");
    }

    [UnityEditor.MenuItem("Delete/Player Data")]
    public static void DeletPlayerData()
    {
        ClearDictionary(Application.persistentDataPath);
        Debug.Log("Delet Player Data");
    }
    static void ClearDictionary(string path)
    {  if(Directory.Exists(path))
        {
            FileInfo[] f = new DirectoryInfo(path).GetFiles("*");
            for(int i = 0;i < f.Length;i++)
            {
                Debug.Log($"Delete{f[i].Name}");
                File.Delete(f[i].FullName);
            }
        }
    }
#endregion

}