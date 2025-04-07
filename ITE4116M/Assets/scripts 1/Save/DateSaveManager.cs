using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class CardList
{
    public List<string> cardList = new List<string>();
}
[System.Serializable]
public class PlayerList
{
    public List<CardList> playerList = new List<CardList>();
}

public class DateSaveManager : MonoBehaviour
{
    public static DateSaveManager instance = new DateSaveManager();

    private void Awake()
    {
        instance = this;
    }
    private string Filepath = Application.streamingAssetsPath + "/PlayerData.json";
    public PlayerList list = new PlayerList();
    public CardList player;
    CardList useCardList;
    public List<string> currcardList = new List<string>();

    public void GenerateData()
    {
        if (!File.Exists(Filepath))
        {
            player = new CardList();
            player.cardList.Add("1000");
            player.cardList.Add("1000");
            player.cardList.Add("1000");
            player.cardList.Add("1000");
            player.cardList.Add("1000");
            player.cardList.Add("1000");
            player.cardList.Add("1000");
            player.cardList.Add("1000");
            player.cardList.Add("1000");
            player.cardList.Add("1000");
            list.playerList.Add(player);
        }
    }

    void SaveData()
    {
        player.cardList = currcardList;
        string json = JsonUtility.ToJson(list , true);
        string Filepath = Application.streamingAssetsPath + "/PlayerData.json";
        
        using(StreamWriter sw = new StreamWriter(Filepath))
        {
            sw.WriteLine(json);
            sw.Close();
            sw.Dispose();
        }
    }

     public List<string> LoadData()
    {
        string json;
        string Filename = Application.streamingAssetsPath + "/PlayerData.json";

        if (File.Exists(Filename))
        {
            using (StreamReader sr = new StreamReader(Filename))
            {
                json = sr.ReadToEnd();
                sr.Close();
            }

            list = JsonUtility.FromJson<PlayerList>(json);
            player = list.playerList[0];
            currcardList.AddRange(player.cardList);
        }
        else
        {
            GenerateData();
        }
        return currcardList;
    }
    public void AddCardtoCardList(string id)
    {
        this.currcardList.Add(id);
        SaveData();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
    }

}
