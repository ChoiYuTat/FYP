using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class SaveSystem
{
    public static string shotPath=$"{Application.persistentDataPath}/Shot";
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
    #region PrtSc
    public static void CameraCapture (int i ,Camera camera,Rect rect)
    {
        if(!Directory.Exists(SaveSystem.shotPath))
        {  
            Directory.CreateDirectory(SaveSystem.shotPath);
        }
        string path = Path.Combine(SaveSystem.shotPath, $"{i}.png");
       

            int w=(int)rect.width;
            int h=(int)rect.height;

            RenderTexture rt = new RenderTexture(w, h, 0);
            camera.targetTexture = rt;
            camera.Render();

            RenderTexture.active=rt;

            Texture2D t2D = new Texture2D(w, h, TextureFormat.RGB24, true);

            t2D.ReadPixels(rect, 0, 0);
            t2D.Apply();

        byte[]bytes=t2D.EncodeToPNG();
        File.WriteAllBytes(path, bytes);

        camera.targetTexture=null;
        RenderTexture.active=null;
        GameObject.Destroy(rt);
    }

    public static Sprite LoadShot(int i)
    {
        var path = Path.Combine(shotPath, $"{i}.png");

        Texture2D t = new Texture2D(640, 360);
        t.LoadImage(GetImgByte(path));
        return Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
    }

    static byte[] GetImgByte(string path)
    {
        FileStream s = new FileStream(path, FileMode.Open);
        byte[] imgByte = new byte[s.Length];
        s.Read(imgByte,0,imgByte.Length);
        s.Close();
        return imgByte;
    }

    public static void DeleteShot(int i)
    {
        var path = Path.Combine(shotPath, $"{i}.png");
        if(File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"deleted image");
        }
    }
        #endregion
    #region DeleteAll
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Delete/Records List")]
    
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

    [UnityEditor.MenuItem("Delete/All")]
    
    public static void DeleteAll()
    {
        DeletPlayerData();
        DeleteRecord();
    }
    #endif
#endregion

}