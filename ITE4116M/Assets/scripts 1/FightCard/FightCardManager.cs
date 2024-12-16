using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager : MonoBehaviour
{
    public static FightCardManager Instance = new FightCardManager();

    public List<string> cardList;//���ƶ�

    public List<string> usedCardList;//���ƶ�
    public void Init()
    {
        cardList = new List<string>();
        usedCardList = new List<string>();

        //temp ���ƶ�
        List<string> tempList = new List<string>();
        //save card temp
        tempList.AddRange(RoleManager.instance.cardList);

        while (tempList.Count > 0)
        {
            //random card
            int tempIndex = Random.Range(0, tempList.Count);
            //add temp card to cardList
            cardList.Add(tempList[tempIndex]);
            //remove temp card
            tempList.RemoveAt(tempIndex);
        }

        Debug.Log(cardList.Count);
    }
}
