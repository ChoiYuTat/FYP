using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogController : MonoBehaviour
{

    public Button fogButton;
    //public float fadeDuration = 3.0f;
    //private bool isFading = false;
    public float fogFadeDuration = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        RenderSettings.fog = true;
        RenderSettings.fogDensity = 1f;
        //fogButton.onClick.AddListener(StatFadeFog);
        fogButton.onClick.AddListener(OnStartButtonClick);
        
    }

    private void OnStartButtonClick()
    {
        StartCoroutine(FadeFogDensity());
        Time.timeScale = 1;
        
    }

    //void StatFadeFog()
    //{
    //    if(!isFading)
    //    {
    //        StartCoroutine(FadeFogDensity());
    //    }
    //}

    System.Collections.IEnumerator FadeFogDensity()
    {
        //isFading = true;
        float startDensity = RenderSettings.fogDensity;
        //float targetDensity = 0.0f;
        float elapsedTime = 1f;

        while (elapsedTime< fogFadeDuration)
        {
            RenderSettings.fogDensity = Mathf.Lerp(startDensity, 0f, elapsedTime / fogFadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //RenderSettings.fogDensity = targetDensity;
        RenderSettings.fog = false;
        //isFading = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
