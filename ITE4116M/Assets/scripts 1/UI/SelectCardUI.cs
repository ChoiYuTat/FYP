using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SelectCardUI : FightUIBase
{
    public Button HP;
    public Button ADD;
    public Button DEL;

    private void Awake()
    {
        HP = transform.Find("bg/content/grid/HP").GetComponent<Button>();
        ADD = transform.Find("bg/content/grid/ADD").GetComponent<Button>();
        DEL = transform.Find("bg/content/grid/DEL").GetComponent<Button>();
        HP.onClick.AddListener(onHP);
        ADD.onClick.AddListener(onAdd);
        DEL.onClick.AddListener(onDEL);
    }

    private void onAdd()
    {
        
    }

    private void onHP()
    {

    }

    private void onDEL()
    {

    }
}
