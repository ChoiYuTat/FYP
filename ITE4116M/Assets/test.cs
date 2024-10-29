using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class test : MonoBehaviour
{
    public BatterCaracte player;
    public TextMeshProUGUI TextMeshProUGUI;
    public Text textl;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.GetInstance().IntitHUD(player);
        TextMeshProUGUI.text = UIManager.GetInstance().playerName.ToString();
        Debug.Log(TextMeshProUGUI.text);
        TextMeshProUGUI.text = player.Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
