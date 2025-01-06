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

        scene1 Scene1 = new scene1();
        SceneControl_Root.dict_scene.Add(Scene1.SceneName,Scene1);

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
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager_Root.Pop(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            scene2 scene = new scene2();
            SceneControl_Root.SceneLoad(scene.SceneName, scene);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            FightManager.Instance.curHp -= 1;
        }
    }
}

