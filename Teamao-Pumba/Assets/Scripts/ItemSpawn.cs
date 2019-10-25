using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawn : MonoBehaviour
{
    public GameObject Item;
    public int Item_qtd;
    public float Cooldown;
    private bool Game_started;
    
    void Start()
    {
        Game_started = false;
        InvokeRepeating("SpawnItems",1, Cooldown); /*Invoca o comando SpawnItems a cada Cooldown segundos*/
    }

    
    void Update()
    {
        if (!Game_started)
        {
            if (gameObject.GetComponent<GameManager>().Countdown < 3)
            {
                Game_started = true;
            }
                
        }
        
    }

    void SpawnItems()
    {
        if (Game_started)
        {
            for (int i = 0; i < Item_qtd; i++)
            {
                float raio = Random.Range(0, 6.0f);                                                             //Escolhe distancia da origem do spawn
                float angulo = Random.Range(0, 2 * Mathf.PI);                                                   //Escolhe direcao do spawn
                Vector3 pos = new Vector3(Mathf.Sin(angulo) * raio, 0.45f, Mathf.Cos(angulo) * raio);
                GameObject I = Instantiate(Item, this.transform);                                                  //Instancia copia de Item
                I.transform.localPosition = pos;                                                                //Move a instancia para a posicao sorteada
            }
        }
    }

}
