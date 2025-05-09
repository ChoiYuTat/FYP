using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class ExitGame : MonoBehaviour
{

    public string charName = "windy";

    private bool canChat = false;

    public GameRoot gameRoot;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
                Flowchart flowchart = GameObject.Find("Flowchart(exitGame)").GetComponent<Flowchart>();
                if (flowchart.HasBlock(charName))
                {
                    flowchart.ExecuteBlock("Exit");
                }
                //gameRoot.currentGameState = GameRoot.GameState.SecondGame;
            }
        }
    }
}
