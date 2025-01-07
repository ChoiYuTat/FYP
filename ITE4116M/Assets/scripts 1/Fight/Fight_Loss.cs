using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_Loss : FightUnit
{
    public override void Init()
    {
        FightManager.Instance.StopAllCoroutines();
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
