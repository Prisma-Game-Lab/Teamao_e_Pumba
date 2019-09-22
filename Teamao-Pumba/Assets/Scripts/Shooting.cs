using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
Script para fazer os jogadores atirarem
 
     
Author: Nagib
***/
public class Shooting : MonoBehaviour
{

    private float timeSinceLastShot;
    private PointSystemPai pontos;

    public float shotCooldown;
    public Component projectile;

    private void Start()
    {
        pontos = this.GetComponent<PointSystemPai>();
    }
    void Update()
    {
        if (Input.GetButton("PressButton" + this.name[(this.name).Length - 1]))
        {
            if (PodeAtirar())
            {
                Atira();
                timeSinceLastShot = 0.0F;
            }
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }
    public bool PodeAtirar() { 
    
        if(pontos.VirtualPoints > 0){
            return (timeSinceLastShot >= shotCooldown);
        }
        return false;
    }

    private void Atira()
    {
        Transform personagem = this.gameObject.GetComponent<CharacterSelect>().personagem.GetComponent<Transform>();

        Component p = Instantiate(projectile, personagem.position + Vector3.up * 0.3f, personagem.rotation);
        p.gameObject.SetActive(true);
        p.GetComponent<ProjectileBehavior>().dono = this.GetComponent<GameObject>();
        pontos.VirtualPoints = pontos.VirtualPoints - 1;

        p.GetComponent<Renderer>().material.SetColor("_Color", this.GetComponent<Renderer>().material.GetColor("_Color"));
    }
}

