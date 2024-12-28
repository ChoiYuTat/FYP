using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        base.Init();
        FightUIManager.Instance.ShowTip("PlayerTure", Color.green, delegate ()
        {
            FightUIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4);
            FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();
        });
    }


    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
