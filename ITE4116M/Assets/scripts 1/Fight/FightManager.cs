using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FightType
{
    None,
    Init,
    Player,
    Enemy,
    Win,
    Loss
}
public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit;

    public int MaxHp;
    public int curHp;
    public int MaxPowerCount;
    public int curPowerCount;
    public int DefenseCount;

    public void Init()
    {
        MaxHp = 10;
        curHp = MaxHp;
        MaxPowerCount = 5;
        curPowerCount = MaxPowerCount;
        DefenseCount = 10; 
    }
    private void Awake()
    {
        Instance = this;
    }

    public void ChangeType(FightType type)
    {
        switch (type)
        {
            case FightType.None:
                break;
            case FightType.Win:
                fightUnit = new Fight_Win();
                break;
            case FightType.Enemy:
                fightUnit = new Fight_EnemyTurn();
                break;
            case FightType.Init:
                fightUnit = new FightInit();
                Debug.Log("FightInit");
                break;
            case FightType.Loss:
                fightUnit = new Fight_Loss();
                break;
            case FightType.Player:
                fightUnit = new Fight_PlayerTurn();
                break;
        }
        fightUnit.Init();
    }
    // Update is called once per frame
    private void Update()
    {
        if (fightUnit != null)
        {
            fightUnit.OnUpDate();
        }
        
    }
}
