using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
