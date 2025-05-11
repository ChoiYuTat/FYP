using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightInit : FightUnit
{
    public override void Init()
    {
        int index = Random.Range(10001, 10004);
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Boss") 
        {
            EnemyManager.instance.LoadRes("10005");

        }
        else
        {
            EnemyManager.instance.LoadRes(index.ToString());
        }
        FightCardManager.Instance.Init();
        FightUIManager.Instance.ShowUI<FightUI>("FightUI");
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
