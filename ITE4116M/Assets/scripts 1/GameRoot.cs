using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameRoot : MonoBehaviour
{
    int i = 0;
    private static GameRoot instance;
    
    public CharacteBase player;
    public CharacteBase enemy;
    
    private UIManager UIManager;
    public UIManager UIManager_Root;

    public BatterCaracte BatterCaracte;
    public BatterEmeny BatterEmeny;

    public UIManager PlayerHUD;
    public UIManager EnemyHUD;

    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public GameObject DialogPrefab;

    public Dialog dialog;

    public Transform Playertransform;
    public Transform Enemytransform;

    public Transform[] BattleChoosePos;
    public GameObject chooseAction;
    public GameObject choosePanel;

    public enum BatterState
    {
        Start,PlayerTurn,EnemyTurn,Win,Lose,Wait
    }
    public BatterState State;
    public TextMeshProUGUI dualogText;
    private SceneControl SceneControl;
    public SceneControl SceneControl_Root { get => SceneControl; }

    public static GameRoot GetInstance() 
    {
        if (instance == null)  
        {
            Debug.LogWarning("GameRoot Ins is false!");
            return instance;
        }

        return instance;
    }

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }

        UIManager = new UIManager();
        UIManager_Root = UIManager;
        SceneControl = new SceneControl();
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        UIManager_Root.CanvasObj = UIMethods.GetInstance().FindCanvas();
        State = BatterState.Start;
        StartCoroutine(SetupBatter());
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIManager.dict_uiObject.ContainsKey("MainMenuPanel"))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager_Root.Push(new MainMenuPanel());
            }
        }
        if (State == BatterState.PlayerTurn)
        {
            BattleChoose();
        }
    }

    public void batterStar()
    {
        State =  BatterState.Start;
        StartCoroutine(SetupBatter());
    }

    private IEnumerator SetupBatter()
    {
        Debug.Log("::" + PlayerHUD.playerName);
        if (Playertransform != null && Enemytransform != null)
        {
            Instantiate(PlayerPrefab, Playertransform.position, Quaternion.identity);
            Instantiate(EnemyPrefab, Enemytransform.position, Quaternion.identity);
        }
        UIManager_Root.Push(new DialogPanel());
        yield return new WaitForSeconds(1.5f);


        if(BatterCaracte.speed > BatterEmeny.speed)
        {
            State = BatterState.PlayerTurn;
            PlayerTurn();
            Debug.Log(BatterCaracte.speed);
        }
        else
        {
            State = BatterState.EnemyTurn;
            dialog.changeText("Enemy Turn");
            Debug.Log(BatterEmeny.speed);
        }
    }

    private void PlayerTurn()
    {
        dialog.changeText("Your Turn");
        UIManager_Root.Push(new ChoosePanel());
    }

    private void BattleChoose()
    {
        Debug.Log(i);
        if (i > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                i -= 1;
                chooseAction.transform.position = BattleChoosePos[i].position;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            i += 1;
            chooseAction.transform.position = BattleChoosePos[i].position;
        }
        if (i == BattleChoosePos.Length)
        {
            i = 0;
            chooseAction.transform.position = BattleChoosePos[i].position;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            switch (i)
            {
                case 0:
                    StartCoroutine(PlayerAttack());
                    break;
                case 1:
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator PlayerAttack()
    {
        dialog.changeText("Player Attack");

        bool isDefeated = enemy.TakeDamege(player.Attack, enemy.Defend);
        yield return new WaitForSeconds(1.5F);
        float dm = player.Attack - enemy.Defend;
        EnemyHUD.UpdateHp(enemy.currentHp);
        if (isDefeated)
        {
            UIManager_Root.Pop(choosePanel);
            State = BatterState.Win;
        }
        else
        {
            choosePanel.SetActive(false);
            State = BatterState.Wait;
        }

    }
}
