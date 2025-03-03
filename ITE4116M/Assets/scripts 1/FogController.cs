using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogController : MonoBehaviour
{

    public Button fogButton;
    private bool isFogEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        fogButton.onClick.AddListener(ToggleFog);    
    }


    void ToggleFog()
    {
        isFogEnabled = !isFogEnabled;
        RenderSettings.fog = isFogEnabled;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
