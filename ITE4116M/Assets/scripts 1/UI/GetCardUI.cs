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
            cardIndex = UnityEngine.Random.Range(1000, 1002);
            switch (cardIndex)
            {
                case 1000:
                    text[i].text = "Actten";
                    btn[i].onClick.AddListener(() =>
                    {
                        getAtt();
                    });

                    break;
                case 1001:
                    text[i].text = "Deffect";
                    btn[i].onClick.AddListener(() =>
                    {
                        getDef();
                    });
                    break;
                case 1002:
                    text[i].text = "AddCard";
                    btn[i].onClick.AddListener(() => { getAddCard(); });
                    break;
            }
        }
    }

    private void getAddCard()
    {
        DateSaveManager.instance.AddCardtoCardList("1002");
        SceneManager.LoadScene("TestBattle");
        FightUIManager.Instance.CloseAllUI("GetCardUI");
    }

    private void getDef()
    {
        DateSaveManager.instance.AddCardtoCardList("1001");
        SceneManager.LoadScene("TestBattle");
        FightUIManager.Instance.CloseAllUI("GetCardUI");
    }

    private void getAtt()
    {
        DateSaveManager.instance.AddCardtoCardList("1000");
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
