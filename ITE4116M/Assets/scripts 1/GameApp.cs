using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        GameConfigManager.Instance.Init();
        RoleManager.instance.Init();
        FightManager.Instance.ChangeType(FightType.Init);
        AudioManager.Instance.Init();
        DateSaveManager.instance.GenerateData();
    }
}
