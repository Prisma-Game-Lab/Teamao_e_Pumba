using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
Script para fazer os projeteis interagirem com outros jogadores e bases
 
     
Author: Nagib
***/
public class ProjectileBehavior : MonoBehaviour
{

    public float projectileSpeed;
    public float stunDuration;
    [HideInInspector]
    public GameObject dono;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.forward * Time.deltaTime * projectileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != dono)
        {
            Destroy(this.gameObject);

            if (other.gameObject.tag.Substring(0, 6) == "Player")
            {
                other.GetComponent<MovimentAxis>().stunSelf(stunDuration);
            }
        }
    }




}
