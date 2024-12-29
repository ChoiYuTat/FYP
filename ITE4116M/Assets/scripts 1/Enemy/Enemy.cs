using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ActionType
{
    None,
    Defend,
    Attack,
}
public class Enemy : MonoBehaviour
{

    protected Dictionary<string, string> data;
    public ActionType type;

    public GameObject hpItemObj;
    public GameObject actionObj;

    public Transform attackTf;
    public Transform defendTf;
    public Text defendTxt;
    public Text hpTxt;
    public Image hpImage;

    public int Defend;
    public int Attack;
    public int MaxHP;
    public int CurHP;


    public void Init(Dictionary<string,string> data)
    {
        this.data = data;
    }
    // Start is called before the first frame update
    void Start()
    {
        type = ActionType.None;
        hpItemObj = FightUIManager.Instance.CreateHpItem();
        actionObj = FightUIManager.Instance.CreateActionIcon();

        attackTf = actionObj.transform.Find("attack");
        defendTf = actionObj.transform.Find("defend");

        defendTxt = hpItemObj.transform.Find("fangyu/Text").GetComponent<Text>();
        hpTxt = hpItemObj.transform.Find("hpTxt").GetComponent<Text>();
        hpImage = hpItemObj.transform.Find("fill").GetComponent<Image>();

        hpItemObj.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2f);
        actionObj.transform.position = Camera.main.WorldToScreenPoint(transform.Find("head").position + new Vector3(0,0.5f,0));

        SetRandomAction();

        Attack = int.Parse(data["Attack"]);
        MaxHP = int.Parse(data["Hp"]);
        CurHP = MaxHP;
        Defend = int.Parse(data["Defend"]);

        UpdateHp();
        UpdateDefend();
    }
    public void SetRandomAction()
    {
        int ran = Random.Range(0, 3);
        type = (ActionType)ran;

        switch (type)
        {
            case ActionType.None:
                break;
            case ActionType.Defend:
                attackTf.gameObject.SetActive(false);
                defendTf.gameObject.SetActive(true);
                break;
            case ActionType.Attack:
                attackTf.gameObject.SetActive(true);
                defendTf.gameObject.SetActive(false);
                break;
        }
    }     

    public void UpdateHp()
    {
        hpTxt.text = CurHP + "/" + MaxHP;
        hpImage.fillAmount = (float)CurHP / (float)MaxHP;
    }

    public void UpdateDefend()
    {
        defendTxt.text = Defend.ToString();
    }
}
