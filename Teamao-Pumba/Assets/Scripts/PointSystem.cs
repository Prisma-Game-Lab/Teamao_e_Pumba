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
    [HideInInspector]
    public int PlayerPoints; // Pontuação que o player vale
    public int Ammo; // Quantidade de itens por cartuchos
    public int ItemPerSecond; // Items entregues a base por segundo
    private bool TouchingBase = false;
    private bool invuneravel = false;

    void Start()
    {
        VirtualPoints = 0;
        RealPoints = 0;
        InvokeRepeating("GiveBase",3,1);
    }
    void Update()
    {
        PlayerPoints = VirtualPoints/2 + 15;
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Item") {
            if(VirtualPoints < MaxItem) {
                VirtualPoints += Ammo;
                Destroy(other.gameObject);
            }
            
        }
        if(other.gameObject == MyBase) {
            TouchingBase = true;
        }
        if(other.gameObject.tag == "Espinho") {
            
        }
    }
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject == MyBase) {
            TouchingBase = false;
        }
    }
    public void loosePoints()
    {
        VirtualPoints--;
    }
    private void GiveBase() {
        if(TouchingBase && VirtualPoints != 0) {
            RealPoints += ItemPerSecond;
            VirtualPoints -= ItemPerSecond;
        }
    }

    public void GetShot() {
        VirtualPoints = (VirtualPoints*2)/3;
        PlayerPoints = 15;
        StartCoroutine(invunerabilidade());
    }

    public void GivePoints(int Ponto) {
        RealPoints += Ponto;
    }

    IEnumerator invunerabilidade() {
        invuneravel = true;
        yield return new WaitForSeconds(3);
        invuneravel = false;
    }

    public bool IsInvuneravel() {
        if(invuneravel) {
            return true;
        }
        return false;
    }
}
