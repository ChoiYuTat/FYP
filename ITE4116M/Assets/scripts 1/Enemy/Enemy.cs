using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


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

    SkinnedMeshRenderer _mashRenderer;

    public Animator ani;

    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }
    // Start is called before the first frame update
    void Start()
    {
        _mashRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
        ani = transform.GetComponent<Animator>();

        type = ActionType.None;
        hpItemObj = FightUIManager.Instance.CreateHpItem();
        actionObj = FightUIManager.Instance.CreateActionIcon();

        attackTf = actionObj.transform.Find("attack");
        defendTf = actionObj.transform.Find("defend");

        defendTxt = hpItemObj.transform.Find("fangyu/Text").GetComponent<Text>();
        hpTxt = hpItemObj.transform.Find("hpTxt").GetComponent<Text>();
        hpImage = hpItemObj.transform.Find("fill").GetComponent<Image>();

        hpItemObj.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2f);
        actionObj.transform.position = Camera.main.WorldToScreenPoint(transform.Find("head").position + new Vector3(0, 0.5f, 0));

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

    public void OnSelect()
    {
        _mashRenderer.material.SetColor("_OtlColor", Color.red);
    }

    public void OnUnSelect()
    {
        _mashRenderer.material.SetColor("_OtlColor", Color.black);
    }

    public void Hit(int val)
    {
        if (Defend >= val)
        {
            Defend -= val;

            ani.Play("hit", 0, 0);
        }
        else
        {
            val = val - Defend;
            Defend = 0;
            CurHP -= val;
            if (CurHP <= 0)
            {
                CurHP = 0;

                ani.Play("die");

                EnemyManager.instance.DeleteEnemy(this);

                Destroy(gameObject, 1);
                Destroy(actionObj);
                Destroy(hpItemObj);
            }
            else
            {
                ani.Play("hit", 0, 0);
            }

        }

        UpdateDefend();
        UpdateHp();
    }

    public void HideAction()
    {
        attackTf.gameObject.SetActive(false);
        defendTf.gameObject.SetActive(false);
    }

    public IEnumerator DoAction()
    {
        HideAction();

        ani.Play("attack");
        yield return new WaitForSeconds(0.5f);

        switch (type)
        {
            case ActionType.None:
                break;
            case ActionType.Attack:
                FightManager.Instance.GetPlayerHit(Attack);
                Camera.main.DOShakePosition(0.1f, 0.2f, 5, 45); 
                break;
            case ActionType.Defend:
                Defend += 1;
                UpdateDefend();
                break;
        }


        yield return new WaitForSeconds(1);

        ani.Play("idle");
    }

}
