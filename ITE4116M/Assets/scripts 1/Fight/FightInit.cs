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
        FightUIManager.Instance.ShowUI<FightUI>("FightUI");
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
