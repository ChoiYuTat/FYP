using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject[] subPanels;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            bool hasActiveSubPanel = CheckActiveSubPanels();

            if (hasActiveSubPanel)
            {
                CloseAllSubPanels(); 
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
