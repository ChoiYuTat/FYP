using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class FightUI : FightUIBase
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
        cardCountText = transform.Find("hasCard/icon/Text").GetComponent<Text>();
        nocardCountText = transform.Find("noCard/icon/Text").GetComponent<Text>();
        PowerCountText = transform.Find("mana/Text").GetComponent<Text>();
        hpText = transform.Find("hp/moneyTxt").GetComponent<Text>();
        hpImg = transform.Find("hp/fill").GetComponent<Image>();
        defText = transform.Find("hp/fangyu/Text").GetComponent<Text>();
        transform.Find("turnBtn").GetComponent<Button>().onClick.AddListener(onChangeTurnBtn);
    }

    private void onChangeTurnBtn()
    {
        if (FightManager.Instance.fightUnit is Fight_PlayerTurn)
        {
            FightManager.Instance.ChangeType(FightType.Enemy);
        }    
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
            FightCardManager.Instance.Shuffle();
        }
        for (int i = 0; i < count; i++) 
        {   
            GameObject obj = Instantiate(Resources.Load("UI/CardItem"),transform) as GameObject;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1000, -700);
            //var item = obj.AddComponent<CardItem>();
            string cardId = FightCardManager.Instance.DrawCard();
            Dictionary<string, string> data = GameConfigManager.Instance.GetCardById(cardId);
            CardItem item = obj.AddComponent(System.Type.GetType(data["Script"])) as CardItem;
            item.Init(data);
            cardItemList.Add(item);

        }
    }

    public void UpdateCardItemPos()
    {
        float offset = 700.0f / cardItemList.Count;
        Vector2 starPos = new Vector2(-cardItemList.Count / 2.0f * offset + offset * 0.5f, -500);
        for (int i = 0; i < cardItemList.Count; i++)
        {
            cardItemList[i].GetComponent<RectTransform>().DOAnchorPos(starPos, 0.5f);
            starPos.x = starPos.x + offset;
        }
    }

    public void RemoveCard(CardItem item)
    {
        AudioManager.Instance.PlayEffect("Cards/cardShove");

        item.enabled = false;

        FightCardManager.Instance.usedCardList.Add(item.data["Id"]);

        nocardCountText.text = FightCardManager.Instance.usedCardList.Count.ToString();

        cardItemList.Remove(item);

        UpdateCardItemPos();

        item.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1000, -150),0.25f);

        item.transform.DOScale(0, 0.25f);

        Destroy(item.gameObject, 1);


    }

    public void RemoveAllCards()
    {
        for (int i = cardItemList.Count - 1; i >= 0; i--)
        {
            RemoveCard(cardItemList[i]);
        }
    }
}
