using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public GameObject exitGameObject; 
    private void Awake()
    {
        exitGameObject = GameObject.Find("DungeonManager");
    }

    public void destory()
    {
        if (exitGameObject != null)
        {
            Destroy(exitGameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        exitGameObject = GameObject.Find("DungeonManager");
    }
}
