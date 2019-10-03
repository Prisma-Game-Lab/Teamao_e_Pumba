using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sistema de pontos no ponto de vista do player.

Author: Vinny
*/ 

public class PointSystem : MonoBehaviour
{
    
    [HideInInspector]
    public int RealPoints; // Os pontos do Player
    [HideInInspector]
    public int VirtualPoints; // Quantidade de itens sendo carregados
    public GameObject MyBase;
    public int MaxItem;

    void Start()
    {
        VirtualPoints = 0;
        RealPoints = 0;
    }
    void Update()
    {
        if(VirtualPoints >= 1) {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if(VirtualPoints >= 2) {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if(VirtualPoints >= 3) {
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Item") {
            if(VirtualPoints < MaxItem) {
                VirtualPoints++;
                Destroy(other.gameObject);
            }
            
        }
        if(other.gameObject == MyBase) {
            RealPoints += VirtualPoints;
            VirtualPoints = 0;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "Espinho") {
            VirtualPoints = 0;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }


    public void loosePoints(int i)
    {
        for (; i > 0; i--)
        {
            transform.GetChild(VirtualPoints - 1).gameObject.SetActive(false);
            VirtualPoints -= 1;
        }
    }
}
