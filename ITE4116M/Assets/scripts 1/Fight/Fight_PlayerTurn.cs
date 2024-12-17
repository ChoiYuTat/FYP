using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_PlayerTurn : FightUnit
{
    public UpDateData UpDateData;
    public override void Init()
    {
        base.Init();
        UIManager.GetInstance().GetUI<FightUIPanel>("UpDateData").CreateCardItem(4);
    }


    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
