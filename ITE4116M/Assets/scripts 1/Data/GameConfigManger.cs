using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigManger
{
    public static GameConfigManger Instance = new GameConfigManger();

    private GameConfigData cardData;
    private GameConfigData enemyData;
    private GameConfigData levelData;
    private TextAsset textAsset;

    public void Init()
    {
        textAsset = Resources.Load<TextAsset>("Data/card");
        cardData = new GameConfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/enemy");
        enemyData = new GameConfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/level");
        levelData = new GameConfigData(textAsset.text);
    }

    public List<Dictionary<string,string>> GetCardLines()
    {
        return cardData.GetLines();
    }
    public List<Dictionary<string, string>> GetEnemyLines()
    {
        return enemyData.GetLines();
    }
    public List<Dictionary<string, string>> GetLevelLines()
    {
        return levelData.GetLines();
    }

    public Dictionary<string, string> GetCardById(string id)
    {
        return cardData.GetOnById(id);
    }
    public Dictionary<string, string> GetEnemyById(string id)
    {
        return enemyData.GetOnById(id);
    }
    public Dictionary<string, string> GetLevelById(string id)
    {
        return levelData.GetOnById(id);
    }

}
