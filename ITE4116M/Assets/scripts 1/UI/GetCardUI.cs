using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetCardUI : FightUIBase
{
    public Button[] btn;

    public Text[] text;
    int cardIndex;

    private void Awake()
    {
        btn = new Button[3];
        text = new Text[3];
        btn[0] = transform.Find("bg/content/grid/HP").GetComponent<Button>();
        btn[1] = transform.Find("bg/content/grid/ADD").GetComponent<Button>();
        btn[2] = transform.Find("bg/content/grid/DEL").GetComponent<Button>();
        text[0] = transform.Find("bg/content/grid/HP/Text").GetComponent<Text>();
        text[1] = transform.Find("bg/content/grid/ADD/Text").GetComponent<Text>();
        text[2] = transform.Find("bg/content/grid/DEL/Text").GetComponent<Text>();
    }


    private void setCard()
    {
        for (int i = 0; i < 3; i++)
        {
            cardIndex = UnityEngine.Random.Range(1000, 1004);
            switch (cardIndex)
            {
                case 1000:
                    text[i].text = "Attack";
                    btn[i].onClick.AddListener(() =>
                    {
                        GetCard("1000");
                    });

                    break;
                case 1001:
                    text[i].text = "Deffect";
                    btn[i].onClick.AddListener(() =>
                    {
                        GetCard("1001");
                    });
                    break;
                case 1002:
                    text[i].text = "AddCard";
                    btn[i].onClick.AddListener(() => { GetCard("1002"); });
                    break;
                case 1003:
                    text[i].text = "ShieldBash";
                    btn[i].onClick.AddListener(() => { GetCard("1003"); });
                    break;
                case 1004:
                    text[i].text = "ContinuousAttack";
                    btn[i].onClick.AddListener(() => { GetCard("1004"); });
                    break;
                case 1005:
                    text[i].text = "Strongdefense";
                    btn[i].onClick.AddListener(() => { GetCard("1005"); });
                    break;
            }
        }
    }
    private void GetCard(string cardId)
    {
        DateSaveManager.instance.AddCardtoCardList(cardId);
        SceneManager.LoadScene("TestBattle");
        FightUIManager.Instance.CloseAllUI("GetCardUI");
    }

    void Start()
    {
        setCard();
    }

    void Update()
    {
           
    }
}
