using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager
{
    public static RoleManager instance = new RoleManager();

    public List<string> cardList;

    public void Init()
    {
        cardList = new List<string>();
        cardList.Add("1000");
        cardList.Add("1000");
        cardList.Add("1000");
        cardList.Add("1000");

        cardList.Add("1000");
        cardList.Add("1000");
        cardList.Add("1001");
        cardList.Add("1001");

        cardList.Add("1002");
        cardList.Add("1002");
    }
}
