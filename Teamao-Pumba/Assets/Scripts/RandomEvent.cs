using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent : MonoBehaviour
{
    public float Probabilidade;
    public int CooldownDoEvento;
    private float NumeroGerado;
    private bool Permition = true;
    void Start()
    {
        InvokeRepeating("GetRandomNumber",3,1);
    }

    
    void Update()
    {
        if(gameObject.GetComponent<GameManager>().Countdown < 0) {
            if(Probabilidade > NumeroGerado) {
                EventChangeBase();
            }
        }
    }
    private void GetRandomNumber() {
        NumeroGerado = Random.Range(0,100.0f);
    }
    private void EventChangeBase() {
        if(Permition) {
             Vector3 aux = gameObject.GetComponent<GameManager>().Bases.transform.GetChild(0).transform.position;
            gameObject.GetComponent<GameManager>().Bases.transform.GetChild(0).transform.position =  gameObject.GetComponent<GameManager>().Bases.transform.GetChild(2).transform.position;
            gameObject.GetComponent<GameManager>().Bases.transform.GetChild(2).transform.position = aux;
            Vector3 aux2 = gameObject.GetComponent<GameManager>().Bases.transform.GetChild(1).transform.position;
            gameObject.GetComponent<GameManager>().Bases.transform.GetChild(1).transform.position = gameObject.GetComponent<GameManager>().Bases.transform.GetChild(3).transform.position;
            gameObject.GetComponent<GameManager>().Bases.transform.GetChild(3).transform.position = aux2;
            Permition = false;
            StartCoroutine(CooldownEvent());
        }
        
    }
    IEnumerator CooldownEvent() {
        yield return new WaitForSeconds(CooldownDoEvento);
        Permition = true;
    }
}
