using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sistema de pontos no ponto de vista do player.

Author: Vinny
*/ 

public class PointSystem : MonoBehaviour
{
    private int VirtualPoints; // Quantidade de itens sendo carregados
    [HideInInspector]
    public int RealPoints; // Os pontos do Player

    void Start()
    {
        VirtualPoints = 0;
        RealPoints = 0;
    }
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Item") {
            if(VirtualPoints < 3) {
                VirtualPoints++;
                Destroy(other.gameObject);
            }
            
        }
        if(other.gameObject.tag == "Base") {
            RealPoints += VirtualPoints;
            VirtualPoints = 0;
        }
    }
}
