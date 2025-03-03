using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogController : MonoBehaviour
{

    public Button fogButton;
    public float fadeDuration = 3.0f;
    private bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        fogButton.onClick.AddListener(StatFadeFog);    
    }

    void StatFadeFog()
    {
        if(!isFading)
        {
            StartCoroutine(FadeFogDensity());
        }
    }

    System.Collections.IEnumerator FadeFogDensity()
    {
        isFading = true;
        float startDensity = RenderSettings.fogDensity;
        float targetDensity = 0.0f;
        float elapsedTime = 0f;
        while (elapsedTime<fadeDuration)
        {
            RenderSettings.fogDensity = Mathf.Lerp(startDensity, targetDensity, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        RenderSettings.fogDensity = targetDensity;
        RenderSettings.fog = false;
        isFading = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
