using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CharacterData
{
    public Vector3 Position;
    public Vector3 Rotation;
    

}

public class CharacterProperty : MonoBehaviour
{
    public CharacterData Property;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Property.Position= transform.position;
        Property.Rotation =transform.eulerAngles;
    }
}
