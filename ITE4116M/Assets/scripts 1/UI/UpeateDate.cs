using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpDateData : MonoBehaviour
{
    public Text cardCountText;
    public Text nocardCountText;
    public Text defText;
    public Image hpImg;
    public Text hpText;
    public Text PowerCountText;

    private void Update()
    {
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
    }
    public void UpdatePower()
    {
        PowerCountText.text = FightManager.Instance.curPowerCount + "/" + FightManager.Instance.MaxPowerCount;
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

}
