using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuPanel : BasePanel
{
    private static string name = "MainMenuPanel";
    private static string path = "Prefab/Panel/Menu/MainMenuPanel";
    public static readonly UIType uIType = new UIType(path, name);
    public MainMenuPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Exit").onClick.AddListener(Exit);
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Save").onClick.AddListener(Save);
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Character").onClick.AddListener(Character);

    }

    private void Character()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new CharacterPanel());
    }
    private void Save()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new SavePanel());
    }
    private void Load()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new CharacterPanel());
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
