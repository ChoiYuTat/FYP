using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SavePanel : BasePanel
{
    private static string name = "SavePanel";
    private static string path = "Prefab/Panel/Menu/SavePanel";
    public static readonly UIType uIType = new UIType(path, name);
    public SavePanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
      
    }

    private void Exit()
    {
        GameRoot.GetInstance().UIManager_Root.Pop(false);
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