using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Sistema de pontos no ponto de vista do player.

Author: Vinny
*/ 

public class PointSystem : MonoBehaviour
{
    
    [HideInInspector]
    public int RealPoints; // Os pontos do Player
    [HideInInspector]
    public int VirtualPoints; // Quantidade de itens sendo carregados
    public int Multiplier; // Multiplicativo dos pontos da base
    public float invunerabilidadeTimer; // Tempo de invunerabilidade
    public GameObject MyBase;
    public int MaxItem;
    [HideInInspector]
    public int PlayerPoints; // Pontuação que o player vale
    public int Ammo; // Quantidade de itens por cartuchos
    public int ItemDelivered; // Items entregues a base
    public int TimeToDeliver; // Tempo para entregar os itens
    public int PointsPerShoot; // Pontos ganhos ao acertar alguem
    public GameObject BaseTimers; // Os tempos UI de cada base para entregar itens
    private bool TouchingBase = false;
    private bool invuneravel = false;
    private float TimeDeliver = 0; // Contador de tempo na base

    public AudioSource Collect;
    public AudioSource BaseSound;
    public AudioSource GetShotSound;
    public AudioSource Berro;



    void Start()
    {
        VirtualPoints = 0;
        RealPoints = 0;
    }
    void Update()
    {
        GiveBase();
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Item") {
            if(VirtualPoints < MaxItem) {
                if(VirtualPoints + Ammo > MaxItem) {
                    VirtualPoints = MaxItem;
                }
                else {
                    VirtualPoints += Ammo;
                }
                Destroy(other.gameObject);
                Collect.Play();
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
            BaseSound.Play();
            BaseTimers.transform.GetChild(0).gameObject.SetActive(true);
            BaseTimers.transform.GetChild(1).gameObject.SetActive(true);
            BaseTimers.transform.GetChild(1).GetComponent<Image>().fillAmount = TimeDeliver/TimeToDeliver;
            TimeDeliver += Time.deltaTime;
            if(TimeDeliver >= TimeToDeliver) {
                if(ItemDelivered > VirtualPoints) {
                    RealPoints += VirtualPoints*Multiplier;
                    VirtualPoints = 0;
                }
                else {
                    RealPoints += ItemDelivered*Multiplier;
                    VirtualPoints -= ItemDelivered;
                }
                TimeDeliver = 0;
            }
        }
        else {
            BaseTimers.transform.GetChild(0).gameObject.SetActive(false);
            BaseTimers.transform.GetChild(1).gameObject.SetActive(false);
            TimeDeliver = 0;
        }
    }

    public void GetShot() {
        GetShotSound.Play();
        Berro.Play();
        VirtualPoints = (VirtualPoints)/3;
        PlayerPoints = PointsPerShoot;
        StartCoroutine(invunerabilidade());
    }

    public void GivePoints(int Ponto) {
        //RealPoints += Ponto;
        RealPoints += PointsPerShoot;
    }

    IEnumerator invunerabilidade() {
        invuneravel = true;
        yield return new WaitForSeconds(invunerabilidadeTimer);
        invuneravel = false;
    }

    public bool IsInvuneravel() {
        if(invuneravel) {
            return true;
        }
        return false;
    }
}
