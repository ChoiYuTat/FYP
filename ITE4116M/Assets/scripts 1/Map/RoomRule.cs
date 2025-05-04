using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRule : MonoBehaviour
{
    public bool isClear = false;
    public GameObject[] DorrPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isClear)
            {
                CloseDoor();
            }
        }
    }




    private void Update()
    {
        if (isClear)
        {
            OpenDoor();
        }
    }
    private void CloseDoor()
    {
        Debug.Log("Door is closed");
        for (int i = 0; i < DorrPrefab.Length; i++)
        {
            DorrPrefab[i].SetActive(true);
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Door is open");
        for (int i = 0; i < DorrPrefab.Length; i++)
        {
            DorrPrefab[i].SetActive(false);
        }
    }
}
