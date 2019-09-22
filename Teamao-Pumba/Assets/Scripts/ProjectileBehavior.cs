using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
Script para fazer os projeteis interagirem com outros jogadores e bases
 
     
Author: Nagib
***/
public class ProjectileBehavior : MonoBehaviour
{
    [HideInInspector]
    public GameObject dono;

    public float projectileSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.forward * Time.deltaTime * projectileSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject != dono)
        {
            Destroy(this);
        }
    }

}
