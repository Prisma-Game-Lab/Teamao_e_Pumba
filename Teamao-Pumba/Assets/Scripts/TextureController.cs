using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureController : MonoBehaviour
{
    
    public Texture MainTexture, StunTexture;
    public GameObject corpo; 
    Renderer renderer;

    void Start()
    {
        renderer = corpo.GetComponent<Renderer> ();
        renderer.material.SetTexture("_MainTex", MainTexture);
    }
}
