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

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {

    }
}
