using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawn : MonoBehaviour
{
    public GameObject Item;
    public Transform Item_parent;
    public int Item_qtd;
    public float Cooldown;
    private bool Game_started;
    
    void Start()
    {
        Game_started = false;
        InvokeRepeating("SpawnItems",3, Cooldown); /*Invoca o comando SpawnItems a cada Cooldown segundos*/
    }

    
    void Update()
    {
        if (!Game_started)
        {
            if (gameObject.GetComponent<GameManager>().Countdown < 0)
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
                pos = pos + Item_parent.position;
                Instantiate(Item, pos, Quaternion.identity);                                                      //Instancia copia de Item na posicao sorteada
            }
        }
    }

}
