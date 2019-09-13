using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
Script para fazer os projeteis interagirem com outros jogadores e bases
 
     
Author: Nagib
***/
public class ProjectileBehavior : MonoBehaviour
{

    public GameObject dono;
    public float projectileSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += projectileSpeed * this.transform.forward;

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject != dono)
        {
            Destroy(this);
        }
    }

}
