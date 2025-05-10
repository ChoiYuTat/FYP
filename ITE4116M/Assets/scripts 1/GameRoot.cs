using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;
using UnityEngine.SceneManagement;

public class GameRoot : MonoBehaviour
{
    private static GameRoot instance;

    private DungeonGenerator DungeonGenerator;
    public DungeonGenerator DungeonGenerator_Root;

    private UIManager UIManager;
    public UIManager UIManager_Root;

    private SceneControl SceneControl;
    public SceneControl SceneControl_Root { get => SceneControl; }




    public Flowchart flowchart;
    public string chatName;
    public GameState currentGameState; 
    public enum GameState
    {
        FirstGame,
        SecondGame,
        Story1End,
        Story2End
    }

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
        DungeonGenerator = new DungeonGenerator();
        DungeonGenerator_Root = DungeonGenerator;
        SceneControl = new SceneControl();
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        UIManager_Root.CanvasObj = UIMethods.GetInstance().FindCanvas();
        currentGameState = GameState.FirstGame;
    }
    void Update()
    {
        switch (currentGameState)
        {
            case GameState.FirstGame:
                if (flowchart.HasBlock(chatName))
                {
                    Debug.Log("Executing block: " + chatName);
                    flowchart.ExecuteBlock("startHint");
                    currentGameState = GameState.SecondGame;
                }
                break;
            case GameState.SecondGame:
                    
                break;

            case GameState.Story1End:

                break;

                case GameState.Story2End:

                break;
        }

        //if (!UIManager.dict_uiObject.ContainsKey("MainMenuPanel"))
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        UIManager_Root.Push(new MainMenuPanel());
        //    }
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        UIManager_Root.Pop(false);
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.B))
        {
            scene2 scene2 = new scene2();
            SceneControl_Root.SceneLoad(scene2.SceneName, scene2);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            FightManager.Instance.curHp -= 1;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            BackHome();
        }
        

    }



    public void BackHome()
    {
        scene1 Scene1 = new scene1();
        SceneControl_Root.SceneLoad(Scene1.SceneName, Scene1);
    }

    
}

