using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteBase : MonoBehaviour
{
    public string Name;
    public float MaxHp;
    public float currentHp;
    public float MaxMp;
    public float currentMp;
    public float Attack;
    public float Defend;
    public float Level;
    public float MaxExp;
    public float currentExp;
    public float speed;
    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        currentHp = MaxHp;
        currentMp = MaxMp;

    }

    protected virtual float ChangHp(float num)
    {

        currentHp = Mathf.Clamp(currentHp + num, 0, MaxHp);
        if(currentMp <= 0)
        {

        }
        return currentHp;
    }

    protected virtual float ChangMp(float num)
    {

        currentMp = Mathf.Clamp(currentMp + num, 0, MaxMp);
        if (currentMp <= 0)
        {

        }
        return currentMp;
    }

    public bool TakeDamege(float atk , float def)
    {
        float dmg = atk - def;
        ChangHp(-dmg);
        if (currentHp <= 0)
            return true;
        else
            return false;
    }
}
