using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    //private static SetActive instance;
    //private UIManager UIManager;
    //public UIManager UIManager_Root;
    public List <Button> button;

    public GameObject option;
    public GameObject userguide;
    public GameObject image;
    public GameObject menu;
    public bool isActive;
    

    //public static SetActive GetInstance()
    //{
    //    if (instance == null)
    //    {
    //        Debug.LogWarning("GameRoot Ins is false!");
    //        return instance;
    //    }

    //    return instance;
    //}

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }

    //    UIManager = new UIManager();
    //    UIManager_Root = UIManager;
    //}
        // Start is called before the first frame update
        void Start()
    {
        if (menu != null)
        {
            isActive = menu.activeSelf;
        }

       
        //UIManager_Root.CanvasObj = UIMethods.GetInstance().FindCanvas();
        foreach (Button btn in button)
        {
            Button currentBtn = btn; 
            currentBtn.onClick.AddListener(() => OnButtonClicked(currentBtn));
        }

        void OnButtonClicked(Button clickedBtn)
        {
            foreach (Button btn in button)
            {
                
                btn.interactable = (btn == clickedBtn);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
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
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isActive =!isActive;
                menu.SetActive(isActive);
            }
            
        }

        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Enabled();
                foreach (Button btn in button)
                {
                    btn.interactable = true;
                }
            }
        }
    }

    private void Enabled()
    {
        option.SetActive(false);
        userguide.SetActive(false);
        image.SetActive(true);
    }

   public void Exit()
    {
        Application.Quit();
    }

   
    }
