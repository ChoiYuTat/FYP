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
    public PlayerList list = new PlayerList();
    CardList player;

    void GenerateData()
    {
        player = new CardList();
        player.cardList.Add("1000");
        player.cardList.Add("1000");
        player.cardList.Add("1000");
        player.cardList.Add("1000");
        player.cardList.Add("1000");

        list.playerList.Add(player);
    }

    void SaveData()
    {
        string json = JsonUtility.ToJson(list);
        string Filepath = Application.streamingAssetsPath + "/PlayerData.json";

        using(StreamWriter sw = new StreamWriter(Filepath))
        {
            sw.WriteLine(json);
            sw.Close();
            sw.Dispose();
        }
    }

    private void Start()
    {
        GenerateData();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)){
            SaveData();
        }
    }

}
