using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class TestNPCcontrol : MonoBehaviour
{

    public string charName = "windy";

    private bool canChat = false;


    private void OnTriggerEnter(Collider other)
    { 
        if(other.tag == "Player")
        {
            canChat = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canChat = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Say();
        
    }

    private void Say()
    {
        if (canChat)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Flowchart flowchart = GameObject.Find("Flowchart(windy)").GetComponent<Flowchart>();
                if (flowchart.HasBlock(charName))
                {
                    flowchart.ExecuteBlock("windy");
                }
            }
        }
    }
}
