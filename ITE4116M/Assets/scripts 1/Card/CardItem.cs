using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;


public class CardItem : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler,IDragHandler,IEndDragHandler,IBeginDragHandler
{
    public Dictionary<string, string> data;
    private int indexer;
    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.1f, 0.1f);
        indexer = transform.GetSiblingIndex();
        transform.SetAsLastSibling();

        transform.Find("bg").GetComponent<Image>().material.SetColor("_lineColor", Color.yellow);
        transform.Find("bg").GetComponent<Image>().material.SetFloat("_lineWidth", 10);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.1f);
        transform.SetSiblingIndex(indexer);

        transform.Find("bg").GetComponent<Image>().material.SetColor("_lineColor", Color.black);
        transform.Find("bg").GetComponent<Image>().material.SetFloat("_lineWidth", 1);
    }

    private void Start()
    {
        transform.Find("bg").GetComponent<Image>().sprite = Resources.Load<Sprite>(data["BgIcon"]);
        transform.Find("bg/icon").GetComponent<Image>().sprite = Resources.Load<Sprite>(data["Icon"]);
        transform.Find("bg/msgTxt").GetComponent<Text>().text = string.Format(data["Des"],data["Arg0"]);
        transform.Find("bg/nameTxt").GetComponent<Text>().text = data["Name"];
        transform.Find("bg/useTxt").GetComponent<Text>().text = data["Expend"];

        transform.Find("bg/Text").GetComponent<Text>().text = GameConfigManager.Instance.GetCardTypeById(data["Type"])["Name"];

        transform.Find("bg").GetComponent<Image>().material = Instantiate(Resources.Load<Material>("Mats/outline"));

    }

    Vector2 initPos;
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        initPos = transform.GetComponent<RectTransform>().anchoredPosition;

        AudioManager.Instance.PlayEffect("Cards/draw");
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera,
            out pos
            ))
        {
            transform.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().anchoredPosition = initPos;
        transform.SetSiblingIndex(indexer);
    }

    public virtual bool TryUse()
    {
        int cost = int.Parse(data["Expend"]);

        if(cost > FightManager.Instance.curPowerCount)
        {
            AudioManager.Instance.PlayEffect("Effect/loss");

            FightUIManager.Instance.ShowTip("No Mana", Color.red);

            return false;
        }
        else
        {

            FightManager.Instance.curPowerCount -= cost;

            FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdatePower();

            FightUIManager.Instance.GetUI<FightUI>("FightUI").RemoveCard(this);
             
            return true;
        }
    }

    public void PlayEffect(Vector3 pos)
    {
        GameObject effectObj = Instantiate(Resources.Load(data["Effects"])) as GameObject;
        effectObj.transform.position = pos;
        Destroy(effectObj, 2);
    }
}
