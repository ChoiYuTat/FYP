using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fight_Win : FightUnit
{
    GameRoot gameRoot;
    //Flowchart flowchart = GameObject.Find("Flowchart(windy)").GetComponent<Flowchart>();
    //string story = flowchart.GetGlobalVariable<string>("selectedStory");
    

    public override void Init()
    {
        FightUIManager.Instance.ShowTip("Victory!!!", Color.green, delegate ()
        {
            FightManager.Instance.StopAllCoroutines();
            FightUIManager.Instance.CloseAllUI("FightUI");
            UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Boss")
            {
                //Flowchart flowchart = GameObject.Find("Flowchart(windy)").GetComponent<Flowchart>();
                //flowchart.SetVariable<BooleanVariable>("GameEnd", true);

                
                //gameRoot.currentGameState = GameRoot.GameState.Story1End;

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
                BooleanVariable gameEndVar = flowchart.GetVariable<BooleanVariable>("GameEnd");
                gameEndVar.Value = true;
            }
            else
            {
                FightUIManager.Instance.ShowUI<GetCardUI>("GetCardUI");
            }
        });
        
    }

    public override void OnUpDate()
    {
        base.OnUpDate();
    }

}
