using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_Loss : FightUnit
{
    public override void Init()
    {
        FightUIManager.Instance.ShowTip("Fail!!!", Color.red, delegate ()
        {
            FightManager.Instance.StopAllCoroutines();
        });
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
