using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public List<Button> button;
    public GameObject menuPanel;
    public GameObject[] subPanels;

    private void Start()
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            bool hasActiveSubPanel = CheckActiveSubPanels();

            if (hasActiveSubPanel)
            {
                CloseAllSubPanels();
                foreach (Button btn in button)
                {
                    btn.interactable = true;
                }
            }
            else
            {
                ToggleMainMenu(); 
            }
        }
    }

    bool CheckActiveSubPanels()
    {
        foreach (GameObject panel in subPanels)
        {
            if (panel.activeSelf) return true;
        }
        return false;
    }

    void CloseAllSubPanels()
    {
        foreach (GameObject panel in subPanels)
        {
            panel.SetActive(false);
        }
    }

    void ToggleMainMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);

      
    }

    
    public void OpenSubPanel(GameObject targetPanel)
    {
        
        if (!menuPanel.activeSelf)
        {
            menuPanel.SetActive(true);
        }

        
        CloseAllSubPanels();

        
        targetPanel.SetActive(true);
    }
}
