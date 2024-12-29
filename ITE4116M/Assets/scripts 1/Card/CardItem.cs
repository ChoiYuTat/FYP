using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;


public class CardItem : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler,IDragHandler,IEndDragHandler
{
    public Dictionary<string, string> data;
    private int indexer;
    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(0.6f, 0.1f);
        indexer = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(0.5f, 0.1f);
        transform.SetSiblingIndex(indexer);
    }

    private void Start()
    {
        transform.Find("bg").GetComponent<Image>().sprite = Resources.Load<Sprite>(data["BgIcon"]);
        transform.Find("bg/icon").GetComponent<Image>().sprite = Resources.Load<Sprite>(data["Icon"]);
        transform.Find("bg/msgTxt").GetComponent<Text>().text = string.Format(data["Des"],data["Arg0"]);
        transform.Find("bg/nameTxt").GetComponent<Text>().text = data["Name"];
        transform.Find("bg/useTxt").GetComponent<Text>().text = data["Expend"];

        transform.Find("bg/Text").GetComponent<Text>().text = GameConfigManager.Instance.GetCardTypeById(data["Type"])["Name"];
    }
}
