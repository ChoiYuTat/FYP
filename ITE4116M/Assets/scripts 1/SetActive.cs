using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    public List <Button> button;

    public GameObject option;
    public GameObject userguide;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
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


        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Enabled();
            foreach (Button btn in button)
            {
                btn.interactable = true;
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
