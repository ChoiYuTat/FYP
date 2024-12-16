using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FightUIPanel : BasePanel
{
    private static string name = "FightUIPanel";
    private static string path = "Prefab/Panel/Menu/FightUIPanel";
    public static readonly UIType uIType = new UIType(path, name);
    private Text cardCountText;
    private Text nocardCountText;
    private Text defText;
    private Image hpImg;
    private Text hpText;
    private Text PowerCountText;

    public FightUIPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        hpText = UIMethods.GetInstance().GetOrAddSingleComponentInChild<Text>(ActiveObj, "moneyTxt");
        PowerCountText = UIMethods.GetInstance().GetOrAddSingleComponentInChild<Text>(ActiveObj, "manaText");
        cardCountText = UIMethods.GetInstance().GetOrAddSingleComponentInChild<Text>(ActiveObj, "hasCardText");
        nocardCountText = UIMethods.GetInstance().GetOrAddSingleComponentInChild<Text>(ActiveObj, "noCardText");
        defText = UIMethods.GetInstance().GetOrAddSingleComponentInChild<Text>(ActiveObj, "fangyuText");
        hpImg = UIMethods.GetInstance().GetOrAddSingleComponentInChild<Image>(ActiveObj, "fill");
        UpdateHp();
        UpdatePower();
        UpdateDef();
        UpdateCardCount();
        UpdateUsedCardCount();
    }

    public void UpdateHp()
    {
        hpText.text = FightManager.Instance.curHp + "/" + FightManager.Instance.MaxHp;
        hpImg.fillAmount = (float)FightManager.Instance.curHp / (float)FightManager.Instance.MaxHp;
        Debug.Log(hpText.text);
    }
    public void UpdatePower()
    {
        PowerCountText.text = FightManager.Instance.curPowerCount+ "/" + FightManager.Instance.MaxPowerCount;
    }

    public void UpdateDef()
    {
        defText.text = FightManager.Instance.DefenseCount.ToString();
    }
    public void UpdateCardCount()
    {
        cardCountText.text = FightCardManager.Instance.cardList.Count.ToString();
    }
    public void UpdateUsedCardCount()
    {
        nocardCountText.text = FightCardManager.Instance.usedCardList.Count.ToString();
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
