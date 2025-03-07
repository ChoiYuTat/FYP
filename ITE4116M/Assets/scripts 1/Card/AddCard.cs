using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (TryUse())
        {
            int val = int.Parse(data["Arg0"]);

            if (FightCardManager.Instance.hasCard() == true)
            {
                FightUIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(val);

                FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();

                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.5f));

                PlayEffect(pos);
            }
            else
            {
                base.OnEndDrag(eventData);

            }
        }
        else
        {
            base.OnEndDrag(eventData);
        }
    }
}
