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
        dialog = transform.GetComponent<TextMeshProUGUI>();
    }
    public void changeText(string str)
    {
        GameRoot.GetInstance().dialog = transform.GetComponent<Dialog>();
        Debug.Log("str = " + str);
        dialog.text = str;
    }
}
