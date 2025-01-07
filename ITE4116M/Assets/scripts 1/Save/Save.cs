using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Save : MonoBehaviour
{
    public CharacterProperty savecharatcer;
    public string savetxt;
    public byte[] loadforbyte;
   
    public string loadtxt;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            savetxt = JsonUtility.ToJson(savecharatcer.Property);
            FileStream savefile = new FileStream(Application.dataPath + "/Save" + "/save.sav", FileMode.Create);
            Debug.Log(Application.dataPath + "/Assets" + "/Save" + "/save.sav");
            savefile.Write(System.Text.Encoding.Default.GetBytes(savetxt));
            savefile.Close();
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            FileStream loadfile = new FileStream(Application.dataPath + "/Save" + "/save.sav", FileMode.Open);
            Debug.Log(Application.dataPath + "/Assets" + "/Save" + "/save.sav");
            loadforbyte = new byte[loadfile.Length];
            loadfile.Read(loadforbyte);
            loadfile.Close();
            loadtxt= System.Text.Encoding.Default.GetString(loadforbyte);
            savecharatcer.Property = JsonUtility.FromJson<CharacterData>(loadtxt);
            savecharatcer.transform.position = savecharatcer.Property.Position;
        }
      
    }
}