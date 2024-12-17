using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private List<CardItem> cardItemList;
    public Fight_PlayerTurn fight_Player;

    private void Awake()
    {
        cardItemList = new List<CardItem>();
    }
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

    public void CreateCardItem(int count)
    {
        if(count > FightCardManager.Instance.cardList.Count)
        {
            count = FightCardManager.Instance.cardList.Count;
        }
        for (int i = 0; i < count; i++) 
        {   
            GameObject obj = Instantiate(Resources.Load("UI/CardItem"),transform) as GameObject;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1000, -700);
            var item = obj.AddComponent<CardItem>();
            string cardId = FightCardManager.Instance.DrawCard();
            Dictionary<string, string> data = GameConfigManager.Instance.GetCardById(cardId);
            item.Init(data);
            cardItemList.Add(item);

        }
    }

}
