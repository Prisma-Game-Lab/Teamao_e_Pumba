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
    public GameObject projectile;

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
        GameObject p = Instantiate(projectile, this.transform.position, this.transform.rotation);
        p.SetActive(true);
        p.GetComponent<ProjectileBehavior>().dono = this.GetComponent<GameObject>();
        pontos.VirtualPoints -= 1;
    }
}

