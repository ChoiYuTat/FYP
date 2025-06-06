using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ShieldBash : CardItem, IPointerDownHandler
{

    public override void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public override void OnDrag(PointerEventData eventData)
    {
        
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.Instance.PlayEffect("Cards/draw");

        FightUIManager.Instance.ShowUI<LineUI>("LineUI");
        FightUIManager.Instance.GetUI<LineUI>("LineUI").SetStarPos(transform.GetComponent<RectTransform>().anchoredPosition);

        Cursor.visible = false;
        StopAllCoroutines();
        StartCoroutine(OnMouseDownRight(eventData));
    }


    private IEnumerator OnMouseDownRight(PointerEventData pData)
    {
        while (true)
        {
            if (Input.GetMouseButton(1))
            {
                break;
            }

            Vector2 pos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform.parent.GetComponent<RectTransform>(),
                pData.position,
                pData.pressEventCamera,
                out pos
                ))
            {
                FightUIManager.Instance.GetUI<LineUI>("LineUI").SetEndPos(pos);
                CheckRayToEnemy();
            }

            yield return null;
        }

        Cursor.visible = true;
        FightUIManager.Instance.CloseUI("LineUI");
    }

    Enemy hitEnemy;
    private void CheckRayToEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Enemy")))
        {
            hitEnemy = hit.transform.GetComponent<Enemy>();

            if (Input.GetMouseButtonDown(0))
            {
                StopAllCoroutines();

                Cursor.visible = true;
                FightUIManager.Instance.CloseUI("LineUI");


                if (TryUse())
                {
                    PlayEffect(hitEnemy.transform.position);

                    AudioManager.Instance.PlayEffect("Effect/sword");

                    int val = int.Parse(data["Arg0"]);
                    hitEnemy.Hit(val);
                    FightManager.Instance.DefenseCount += val;
                    FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdateDef();
                }
                hitEnemy.OnUnSelect();
                hitEnemy = null;
            }
        }
        else
        {
            if(hitEnemy != null)
            {
                hitEnemy.OnUnSelect();
                hitEnemy = null;
            }
        }
    }
}


