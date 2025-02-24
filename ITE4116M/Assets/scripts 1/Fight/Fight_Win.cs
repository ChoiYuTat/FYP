using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fight_Win : FightUnit
{
    public override void Init()
    {
        FightUIManager.Instance.ShowTip("Victory!!!", Color.green, delegate ()
        {
            FightManager.Instance.StopAllCoroutines();
            SceneManager.LoadScene("TestBattle");
            FightUIManager.Instance.CloseAllUI("FightUI");
            DungeonGenerator.Instance.Init();
        });
        
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }

}
