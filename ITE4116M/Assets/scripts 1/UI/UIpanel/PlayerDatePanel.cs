using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerDatePanel : BasePanel
{
    public BatterCaracte player;
    private static string name = "PlayerDatePanel";
    private static string path = "Prefab/Panel/Menu/PlayerDatePanel";
    public static readonly UIType uIType = new UIType(path, name);
    public PlayerDatePanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<TextMeshProUGUI>(ActiveObj, "PlayerName").text = GameRoot.GetInstance().PlayerHUD.playerName;
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<TextMeshProUGUI>(ActiveObj, "MPcurrentText").text = GameRoot.GetInstance().PlayerHUD.MP; 
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<TextMeshProUGUI>(ActiveObj, "HPcurrentText").text = GameRoot.GetInstance().PlayerHUD.HP; 
    }
    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnDestory()
    {
        base.OnDestory();
    }
}
