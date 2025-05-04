using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGame : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        player = GameObject.Find("testCharacter");

    }

    private void Start()
    {
        Debug.Log(GameRoot.GetInstance().currentGameState);
        if (GameRoot.GetInstance().currentGameState == GameRoot.GameState.SecondGame)
        {
            player.transform.position = new Vector3(53f, 16f, 35f);
        }
    }
}
