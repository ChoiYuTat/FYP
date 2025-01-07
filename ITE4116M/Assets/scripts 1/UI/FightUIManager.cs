using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FightUIManager : MonoBehaviour
{
    public static FightUIManager Instance;

    private Transform canvasTf;

    private List<FightUIBase> uiList;
    private void Awake()
    {
        Instance = this;

        canvasTf = GameObject.Find("Canvas").transform;

        uiList = new List<FightUIBase>();
    }

    public FightUIBase ShowUI<T>(string uiName) where T : FightUIBase
    {
        FightUIBase ui = Find(uiName);
        if(ui == null)
        {
            Debug.Log(uiName);

            GameObject obj = Instantiate(Resources.Load("UI/"+uiName), canvasTf) as GameObject;

            obj.name = uiName;

            ui = obj.AddComponent<T>();

            uiList.Add(ui);

        }
        else
        {
            ui.Show();
        }

        return ui;
    }

    public void HideUI(string uiName)
    {
        FightUIBase ui = Find(uiName);
        if(ui != null)
        {
            ui.Hide();
        }
    }

    public void CloseUI(string uiName)
    {
        FightUIBase ui = Find(uiName);
        if (ui != null)
        {
            uiList.Remove(ui);
            Destroy(ui.gameObject);
        }
    }

    public void CloseAllUI(string uiName)
    {
        for (int i = uiList.Count - 1; i >= 0; i--)
        {
            Destroy(uiList[i].gameObject);
        }

        uiList.Clear();
    }

    public FightUIBase Find(string name)
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == name)
            {
                return uiList[i];
            }
        }
        return null;
    }

    public T GetUI<T>(string name) where T : FightUIBase
    {
        FightUIBase ui = Find(name);
        if (ui != null)
        {
            return ui.GetComponent<T>();
        }
        return null;
    }

    public void ShowTip(string msg, Color color, System.Action callback = null)
    {
        GameObject obj = Instantiate(Resources.Load("UI/Tips"), canvasTf) as GameObject;
        Text text = obj.transform.Find("bg/Text").GetComponent<Text>();
        text.color = color;
        text.text = msg;
        Tween scale1 = obj.transform.Find("bg").DOScale(1, 0.4f);
        Tween scale2 = obj.transform.Find("bg").DOScale(0, 0.4f);

        Sequence seq = DOTween.Sequence();
        seq.Append(scale1);
        seq.AppendInterval(0.5f);
        seq.Append(scale2);
        seq.AppendCallback(delegate ()
        {
            if(callback != null)
            {
                callback();
            }
        });
        MonoBehaviour.Destroy(obj, 2);
    }
    public GameObject CreateActionIcon()
    {
        GameObject obj = Instantiate(Resources.Load("UI/actionIcon"), canvasTf) as GameObject;
        obj.transform.SetAsLastSibling();
        return obj;
    }
    public GameObject CreateHpItem()
    {
        GameObject obj = Instantiate(Resources.Load("UI/HpItem"), canvasTf) as GameObject;
        obj.transform.SetAsLastSibling();
        return obj;
    }
}
