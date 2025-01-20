using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : BasePanel
{
    private static string name = "Options";
    private static string path = "Prefab/Panel/Menu/Options";
    public static readonly UIType uIType = new UIType(path, name);
    public Options() : base(uIType)
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
    }
}
