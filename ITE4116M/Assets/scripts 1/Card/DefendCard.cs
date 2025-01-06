using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefendCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if(TryUse() == true)
        {
            int val = int.Parse(data["Arg0"]);

            AudioManager.Instance.PlayEffect("Effect/healspell");

            FightManager.Instance.DefenseCount += val;

            FightUIManager.Instance.GetUI<FightUI>("FightUI").UpdateDef();

            Vector3 pos = Camera.main.transform.position;
            pos.y = 0;
            PlayEffect(pos);
        }
        else
        {
            base.OnEndDrag(eventData);
        }

    }
}
