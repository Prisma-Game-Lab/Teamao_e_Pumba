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
    private PointSystem pontos;
    private GameManager gm;

    public float shotCooldown;
    public Component projectile;
  


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
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

        if (gm.Countdown < 0) {
            pontos = this.GetComponentInChildren<PointSystem>();
            if (pontos.VirtualPoints > 0) {
                return (timeSinceLastShot >= shotCooldown);
            }
        }
        return false;
    }

    private void Atira()
    {
        Transform personagem = this.gameObject.GetComponent<CharacterSelect>().personagem.GetComponent<Transform>();

        Component p = Instantiate(projectile, personagem.position + personagem.forward * 0.1f + Vector3.up * 0.3f, personagem.rotation);
        p.gameObject.SetActive(true);

        personagem.GetComponent<PointSystem>().VirtualPoints -= 1;

        p.GetComponent<ProjectileBehavior>().dono = personagem.gameObject;
        p.GetComponent<Renderer>().material.SetColor("_Color", this.GetComponent<Renderer>().material.GetColor("_Color"));
    }
}

