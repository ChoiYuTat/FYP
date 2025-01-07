using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class TestNPCcontrol : MonoBehaviour
{

    public string charName = "NPC1";

    private bool canChat = false;


    private void OnTriggerEnter(Collider other)
    {
        canChat = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canChat = false;
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
                Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
                if (flowchart.HasBlock(charName))
                {
                    flowchart.ExecuteBlock("NPC1");
                }
            }
        }
    }
}
