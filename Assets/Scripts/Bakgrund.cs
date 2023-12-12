using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakgrund : MonoBehaviour
{
    public float fart; // st�lla in hastighet

    [SerializeField] // f�r att kunna referera till rendern
    private Renderer bakgrund;

    void Update()
    {
        Vector2 avs�ttning = bakgrund.material.mainTextureOffset; // avs�ttning fr�n materialet
        avs�ttning.x += Time.deltaTime * fart; // uppdatera avs�ttningen i x riktningen basert p� tiden och fart 
        bakgrund.material.mainTextureOffset = avs�ttning; // till�mpa det1

            
    }
}
