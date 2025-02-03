using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class TransparencyController : MonoBehaviour
{
    [SerializeField] private string transparentTag = "wall";
    [SerializeField] private float targetAlpha = 0.9f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(transparentTag))
        {
            SetTransparency(other.gameObject, targetAlpha);        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(transparentTag))
        {
            SetTransparency(other.gameObject, 1.0f);
        }
    }


    private void SetTransparency(GameObject obj,float alpha)
    {
        Renderer render = obj.GetComponent<Renderer>();
        if (render != null) 
        {
            MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
            render.GetPropertyBlock(propBlock);
            Color baseColor = propBlock.GetColor("_BaseColor");
            baseColor.a = alpha;
            propBlock.SetColor("_BaseColor",baseColor);
            render.SetPropertyBlock(propBlock);
        }
    }
}
