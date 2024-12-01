using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyDatePanel : BasePanel
{
    private static string name = "EnemyDatePanel";
    private static string path = "Prefab/Panel/Menu/EnemyDatePanel";
    public static readonly UIType uIType = new UIType(path, name);
    public EnemyDatePanel() : base(uIType)
    {

    }
    public override void OnDestory()
    {
        base.OnDestory();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnStart()
    {
        base.OnStart();
        //UIMethods.GetInstance().GetOrAddSingleComponentInChild<TextMeshProUGUI>(ActiveObj, "PlayerName").text = GameRoot.GetInstance().EnemyHUD.playerName;
        //UIMethods.GetInstance().GetOrAddSingleComponentInChild<TextMeshProUGUI>(ActiveObj, "MPcurrentText").text = GameRoot.GetInstance().EnemyHUD.MP;
        //UIMethods.GetInstance().GetOrAddSingleComponentInChild<TextMeshProUGUI>(ActiveObj, "HPcurrentText").text = GameRoot.GetInstance().EnemyHUD.HP;
    }
}
