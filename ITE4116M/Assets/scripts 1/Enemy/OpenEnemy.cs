using Fungus;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenEnemy : MonoBehaviour
{
    private bool canOpen = false;
    private bool isOpen = false;
    public RoomRule rule;
    public GameObject gameObject; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
        }
    }
    private void Update()
    {

        if (canOpen && !isOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
             
                isOpen = true;
                SceneManager.LoadScene("TestBatter");
                rule.isClear = true;
                Destroy(gameObject);
            }
            
        }
    }

}
