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
        UIManager.GetInstance().IntitHUD(player);
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<TextMeshProUGUI>(ActiveObj, "PlayerName").text = UIManager.GetInstance().playerName.ToString();
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
