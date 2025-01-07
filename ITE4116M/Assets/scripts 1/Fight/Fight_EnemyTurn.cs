using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_EnemyTurn : FightUnit
{
    public override void Init()
    {
        FightUIManager.Instance.GetUI<FightUI>("FightUI").RemoveAllCards();
        FightUIManager.Instance.ShowTip("Enemy Turn", Color.red, delegate ()
          {
              
          });
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
