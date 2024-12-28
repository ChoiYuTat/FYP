using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightUIBase : MonoBehaviour
{
    public virtual void Close()
    {
        FightUIManager.Instance.CloseUI(gameObject.name);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
