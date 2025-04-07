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
            FightUIManager.Instance.CloseAllUI("FightUI");
            FightUIManager.Instance.ShowUI<GetCardUI>("GetCardUI");
        });
        
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }

}
