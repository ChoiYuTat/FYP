using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPanel : BasePanel
{
    private static string name = "DialogPanel";
    private static string path = "Prefab/Panel/Menu/DialogPanel";
    public static readonly UIType uIType = new UIType(path, name);
    public DialogPanel() : base(uIType)
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
