using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setChoose : MonoBehaviour
{
    public GameObject chooseAstion;
    public Transform[] BattleChoosePos;
    public GameObject choosePanel;
    void Start()
    {
        GameRoot.GetInstance().choosePanel = choosePanel;
        GameRoot.GetInstance().chooseAction = chooseAstion;
        GameRoot.GetInstance().BattleChoosePos = BattleChoosePos;
    }
    void Update()
    {
        
    }
}
