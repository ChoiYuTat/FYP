using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager 
{
    public static EnemyManager instance = new EnemyManager();

    private List<Enemy> enemyList;
    /// <summary>
    /// Load Enemy Data
    /// </summary>
    /// <param name="id">Level Id</param>
    public void LoadRes(string id)
    {
        enemyList = new List<Enemy>();

        Dictionary<string, string> levelDate = GameConfigManager.Instance.GetLevelById(id);

        string[] enemyIds = levelDate["EnemyIds"].Split("=");

        string[] enemyPos = levelDate["Pos"].Split("=");

        for(int i = 0; i<enemyIds.Length; i++)
        {
            string enemyId = enemyIds[i];
            string[] posArr = enemyPos[i].Split(",");

            float x = float.Parse(posArr[0]);
            float y = float.Parse(posArr[1]);
            float z = float.Parse(posArr[2]);

            Dictionary<string, string> enemyData = GameConfigManager.Instance.GetEnemyById(enemyId);

            GameObject obj = Object.Instantiate(Resources.Load(enemyData["Model"])) as GameObject;

            Enemy enemy = obj.AddComponent<Enemy>();

            enemy.Init(enemyData);

            enemyList.Add(enemy);

            obj.transform.position = new Vector3(x, y, z);
        }
    }
}
