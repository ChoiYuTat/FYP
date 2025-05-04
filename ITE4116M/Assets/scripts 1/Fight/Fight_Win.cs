using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fight_Win : FightUnit
{
    GameRoot gameRoot;
    public override void Init()
    {
        FightUIManager.Instance.ShowTip("Victory!!!", Color.green, delegate ()
        {
            FightManager.Instance.StopAllCoroutines();
            FightUIManager.Instance.CloseAllUI("FightUI");
            UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Boss")
            {
                SceneManager.LoadScene("HD_2D_Day");

            }
            else
            {
                FightUIManager.Instance.ShowUI<GetCardUI>("GetCardUI");
            }
        });
        
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }

}
