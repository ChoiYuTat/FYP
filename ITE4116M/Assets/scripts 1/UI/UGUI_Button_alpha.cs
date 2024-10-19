using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UGUI_Button_alpha : MonoBehaviour
{

    public Image image;
    public float threshold = 0.5f;

    void Start()
    {
        image.alphaHitTestMinimumThreshold = threshold;
    }

}