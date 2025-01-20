using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class RoomManager:MonoBehaviour
{
    public enum Direction { up,down,left,right};
    public Direction direction;

    public GameObject roomPrefab;
    public int roomNumber;
    public Color starColor, endColor;
    public GameObject endRoom;

    public Transform generatorPoint;
    public float xOffset;
    public float zOffset;
    public LayerMask roomType;

    public List<GameObject> rooms = new List<GameObject>();


    private void Awake()
    {
        roomPrefab = Resources.Load("BaseRoom") as GameObject;
        starColor = Color.yellow;
        endColor = Color.red;
        xOffset = 36;
        zOffset = 27;
        roomNumber = 10;
    }
    void Start()
    {
        for (int i = 0; i < roomNumber; i++)
        {
            rooms.Add(Object.Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity));
            ChangePointPos();
        }

        rooms[0].GetComponent<MeshRenderer>().material.color = starColor;
        endRoom = rooms[0];
        foreach (var room in rooms)
        {
            if (room.transform.position.sqrMagnitude > endRoom.transform.position.sqrMagnitude)
            {
                endRoom = room;

            }
        }
        endRoom.GetComponent<MeshRenderer>().material.color = endColor;

    }


    private void ChangePointPos()
    {
        bool ifCreated = false;
        do {
            
            direction = (Direction) Random.Range(0, 4);
            switch (direction)
            {
                case Direction.up: generatorPoint.position += new Vector3(0, 0, zOffset); break;
                case Direction.down: generatorPoint.position += new Vector3(0, 0, -zOffset); break;
                case Direction.left: generatorPoint.position += new Vector3(-xOffset, 0, 0); break;
                case Direction.right: generatorPoint.position += new Vector3(xOffset, 0, 0); break;
            }
            ifCreated = ifPositionCreated();
         }while (ifCreated);
    }


    public bool ifPositionCreated()
    {
        foreach (GameObject g in rooms)
        {
            if(g.transform.position == generatorPoint.position)
            {
                return true;
            }
        }return false;
    }
    public void setupRoom(Room newRoom, Vector3 roomPoition)
    {


    }
}
