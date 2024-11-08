using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI dialog;
    private void Start()
    {
        GameRoot.GetInstance().dialog = transform.GetComponent<Dialog>();
        dialog = transform.GetComponent<TextMeshProUGUI>();
    }
    public void changeText(string str)
    {
        Debug.Log("str = " + str);
        dialog.text = str;
    }
}
