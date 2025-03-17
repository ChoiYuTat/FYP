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

    public PlayerList list = new PlayerList();
    public CardList player;
    CardList useCardList;
    public List<string> currcardList = new List<string>();

    public void GenerateData()
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

    void SaveData()
    {
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
        string filename = Application.streamingAssetsPath + "/PlayerData.json";

        if (File.Exists(filename))
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                json = sr.ReadToEnd();
                sr.Close();
            }
            list = JsonUtility.FromJson<PlayerList>(json);
            for (int i = 0; i > this.player.cardList.Count; i++)
            {
                currcardList.Add(player.cardList[i]);
            }
        }
        else
        {
            GenerateData();
        }
        return currcardList;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)){
            SaveData();
        }
    }

}
