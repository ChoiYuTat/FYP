using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoadPanel : BasePanel
{
    private static string name = "LoadPanel";
    private static string path = "Prefab/Panel/Menu/LoadPanel";
    public static readonly UIType uIType = new UIType(path, name);
    public LoadPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Exit").onClick.AddListener(Exit);
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