using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public void Init(Dictionary<string,string> data)
    {
        this.data = data;
    }
    // Start is called before the first frame update
    void Start()
    {
        type = ActionType.None;
        hpItemObj = CreateHpItem();
        actionObj = CreateActionIcon();
        hpItemObj.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -1, 0));
        actionObj.transform.position = Camera.main.WorldToScreenPoint(transform.Find("head").position + new Vector3(0,1,0));
    }

      
    public GameObject CreateActionIcon()
    {
        GameObject obj = Instantiate(Resources.Load("UI/actionIcon"), UIManager.GetInstance().CanvasObj.transform) as GameObject;
        obj.transform.SetAsLastSibling();
        return obj;
    }
    public GameObject CreateHpItem()
    {
        GameObject obj = Instantiate(Resources.Load("UI/HpItem"), UIManager.GetInstance().CanvasObj.transform) as GameObject;
        obj.transform.SetAsLastSibling();
        return obj;
    }
}
