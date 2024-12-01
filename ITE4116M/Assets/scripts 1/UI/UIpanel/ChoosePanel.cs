using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePanel : BasePanel
{
    private static string name = "ChoosePanel";
    private static string path = "Prefab/Panel/Menu/ChoosePanel";
    public static readonly UIType uIType = new UIType(path, name);
    public ChoosePanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
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
