using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        FightUIManager.Instance.ShowTip("PlayerTure", Color.green, delegate ()
        {
            FightManager.Instance.curPowerCount = FightManager.Instance.MaxPowerCount;
            FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdatePower();

            if (FightCardManager.Instance.hasCard() == false)
            {
                FightCardManager.Instance.Init();

                FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdateUsedCardCount();
            }

            FightUIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(6);
            FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();

            FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardCount();

        });
    }


    public override void OnUpDate()
    {
        if (FightCardManager.Instance.hasCard() == false)
        {
            FightCardManager.Instance.Init();

            FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdateUsedCardCount();
        }
    }
}
