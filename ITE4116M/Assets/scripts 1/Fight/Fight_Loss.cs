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
                Debug.LogError("�䤣�� Flowchart(windy) ��H�I");
                return;
            }
            Flowchart flowchart = flowchartObj.GetComponent<Flowchart>();
            if (flowchart == null)
            {
                Debug.LogError("Flowchart �ե󥼧��I");
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
