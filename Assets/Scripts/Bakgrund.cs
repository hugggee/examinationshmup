using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakgrund : MonoBehaviour
{
    public float fart; // ställa in hastighet

    [SerializeField] // för att kunna referera till rendern
    private Renderer bakgrund;

    void Update()
    {
        Vector2 avsättning = bakgrund.material.mainTextureOffset; // avsättning från materialet
        avsättning.x += Time.deltaTime * fart; // uppdatera avsättningen i x riktningen basert på tiden och fart 
        bakgrund.material.mainTextureOffset = avsättning; // tillämpa det1

            
    }
}
