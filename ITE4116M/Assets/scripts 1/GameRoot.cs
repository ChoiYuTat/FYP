using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameRoot : MonoBehaviour
{
    private static GameRoot instance;

    private UIManager UIManager;

    public UIManager UIManager_Root;

    public BatterCaracte BatterCaracte;
    public BatterEmeny BatterEmeny;

    public UIManager PlayerHUD;
    public UIManager EnemyHUD;

    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    public Transform Playertransform;
    public Transform Enemytransform;

    public enum BatterState
    {
        Start,PlayerTurn,EnemyTurn,Win,Lose
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
        if (!UIManager.dict_uiObject.ContainsKey("PlayerDatePanel"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                batterStar();
            }
        }
    }

    public void batterStar()
    {
        State =  BatterState.Start;
        StartCoroutine(SetupBatter());
    }

    private IEnumerator SetupBatter()
    {
        BatterCaracte = PlayerPrefab.GetComponent<BatterCaracte>();
        BatterEmeny = EnemyPrefab.GetComponent<BatterEmeny>();
        PlayerHUD.IntitHUD(BatterCaracte);
        Debug.Log("::" + PlayerHUD.playerName);
        if (Playertransform != null && Enemytransform != null)
        {
            Instantiate(PlayerPrefab, Playertransform.position, Quaternion.identity);
            Instantiate(EnemyPrefab, Enemytransform.position, Quaternion.identity);
        }
        UIManager_Root.Push(new PlayerDatePanel());
        UIManager_Root.Push(new DialogPanel());

        yield return new WaitForSeconds(1.5f);

        if(BatterCaracte.speed > BatterEmeny.speed)
        {
            State = BatterState.PlayerTurn;
        }
        else
        {
            State = BatterState.EnemyTurn;
        }
    }
}
