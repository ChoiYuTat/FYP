using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightInit : FightUnit
{
    public override void Init()
    {
        FightManager.Instance.Init();
        EnemyManager.instance.LoadRes("10003");
        FightCardManager.Instance.Init();
        UIManager.GetInstance().Push(new FightUIPanel());
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
