using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_Win : FightUnit
{
    public override void Init()
    {
        FightUIManager.Instance.ShowTip("Victory!!!", Color.green, delegate ()
        {
            FightManager.Instance.StopAllCoroutines();
        });
        
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
