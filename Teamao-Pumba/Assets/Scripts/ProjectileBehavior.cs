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

        print("Trigger!\n");
        Destroy(this.gameObject);

        print(other.gameObject.tag.Substring(0, 6));

        if (other.gameObject.tag.Substring(0, 6) == "Player")
        {
            other.GetComponent<MovimentAxis>().stunSelf(stunDuration);
        }
    }




}
