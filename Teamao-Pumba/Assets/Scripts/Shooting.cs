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
    public float projectileSpeedBase;
    public float projectileSpeedMultiplier;

    public AudioSource Tiro;

    Animator anim;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (Input.GetButton("ShootPlayer" + transform.parent.name[(transform.parent.name).Length - 1]))
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
    public bool PodeAtirar()
    {

        if (gm.Countdown < 0)
        {
            pontos = this.GetComponent<PointSystem>();
            if (pontos.VirtualPoints > 0)
            {
                return (timeSinceLastShot >= shotCooldown);
            }
        }
        return false;
    }

    private void Atira()
    {
        Tiro.Play();
        Transform personagem = this.GetComponent<Transform>();

        float ms = personagem.GetComponent<MovimentAxis>().movementSpeed;

        Component p = Instantiate(projectile, personagem.position + personagem.forward * 0.1f + Vector3.up * 0.3f, personagem.rotation);
        p.gameObject.SetActive(true);
        Physics.IgnoreCollision(p.GetComponent<Collider>(), this.GetComponent<Collider>());
        personagem.GetComponent<PointSystem>().loosePoints();

        p.GetComponent<ProjectileBehavior>().dono = personagem.gameObject;
        p.GetComponent<ProjectileBehavior>().projectileSpeed = (ms * projectileSpeedMultiplier) + projectileSpeedBase;
        p.GetComponent<Renderer>().material.SetColor("_Color", this.GetComponentInParent<Renderer>().material.GetColor("_Color"));

        anim = this.GetComponent<Animator>();
        anim.SetTrigger("throw");
    }
}

