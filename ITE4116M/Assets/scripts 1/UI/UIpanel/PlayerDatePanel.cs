using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDatePanel : BasePanel
{
    private static string name = "PlayerDatePanel";
    private static string path = "Prefab/Panel/Menu/PlayerDatePanel";
    public static readonly UIType uIType = new UIType(path, name);
    public PlayerDatePanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Text>(ActiveObj, "PlayerDatePanel").

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
