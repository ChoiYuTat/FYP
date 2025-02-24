using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fight_EnemyTurn : FightUnit
{
    public override void Init()
    {
        FightUIManager.Instance.GetUI<FightUI>("FightUI").RemoveAllCards();
        FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdatePower();
        FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardCount();
        FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdateUsedCardCount();
        FightUIManager.Instance.ShowTip("Enemy Turn", Color.red, delegate ()
          {
              FightManager.Instance.StartCoroutine(EnemyManager.instance.DoAllEnemyAction());
          });
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
