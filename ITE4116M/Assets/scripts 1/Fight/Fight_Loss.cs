using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fight_Loss : FightUnit
{
    public override void Init()
    {
        FightUIManager.Instance.ShowTip("Loss", Color.red, delegate ()
        {
            FightManager.Instance.isfirst = true;
            FightManager.Instance.StopAllCoroutines();
            FightUIManager.Instance.CloseAllUI("FightUI");

            SceneManager.LoadScene("HD_2D_Day");

            GameObject flowchartObj = GameObject.Find("Flowchart(windy)");
            if (flowchartObj == null)
            {
                Debug.LogError("找不到 Flowchart(windy) 對象！");
                return;
            }
            Flowchart flowchart = flowchartObj.GetComponent<Flowchart>();
            if (flowchart == null)
            {
                Debug.LogError("Flowchart 組件未找到！");
                return;
            }
            BooleanVariable gameLoseVar = flowchart.GetVariable<BooleanVariable>("GameLose");
            gameLoseVar.Value = true;
            BooleanVariable gameEndVar = flowchart.GetVariable<BooleanVariable>("GameEnd");
            gameEndVar.Value = true;
            DungeonGenerator.Instance.ReloadDungeon();

            
        });
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }
}
