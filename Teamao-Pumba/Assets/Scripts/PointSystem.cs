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
    public int ItemDelivered; // Items entregues a base
    public int TimeToDeliver; // Tempo para entregar os itens
    public int PointsPerShoot; // Pontos ganhos ao acertar alguem
    private bool TouchingBase = false;
    private bool invuneravel = false;
    private float TimeDeliver = 0; // Contador de tempo na base

    void Start()
    {
        VirtualPoints = 0;
        RealPoints = 0;
    }
    void Update()
    {
        PlayerPoints = VirtualPoints;
        GiveBase();
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
            TimeDeliver += Time.deltaTime;
            if(TimeDeliver >= TimeToDeliver) {
                RealPoints += ItemDelivered;
                VirtualPoints -= ItemDelivered;
                TimeDeliver = 0;
            }
        }
        else {
            TimeDeliver = 0;
        }
    }

    public void GetShot() {
        VirtualPoints = (VirtualPoints*2)/3;
        PlayerPoints = PointsPerShoot;
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
