using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI dialog;
    private void Awake()
    {
        dialog.text = "";
    }
    public void changeText(string str)
    {
        Debug.Log("str = " + str);
        dialog.text = str;
    }
}
