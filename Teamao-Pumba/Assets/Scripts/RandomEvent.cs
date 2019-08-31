using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEvent : MonoBehaviour
{
    public GameObject RandomEventCanvas;
    public float Probabilidade;
    public int CooldownDoEvento;
    public float MoveSpeedPlus;
    private float NumeroGerado;
    private bool Permition = true;
    void Start()
    {
        InvokeRepeating("GetRandomNumber",3,1);
    }

    
    void Update()
    {
        if(gameObject.GetComponent<GameManager>().Countdown < 0) {
            if(Probabilidade > NumeroGerado && Permition) {
                ChooseEvent();
            }
        }
    }
    private void GetRandomNumber() {
        NumeroGerado = Random.Range(0,100.0f);
    }
    private void EventChangeBase() {
        Vector3 aux = gameObject.GetComponent<GameManager>().Bases.transform.GetChild(0).transform.position;
        gameObject.GetComponent<GameManager>().Bases.transform.GetChild(0).transform.position =  gameObject.GetComponent<GameManager>().Bases.transform.GetChild(2).transform.position;
        gameObject.GetComponent<GameManager>().Bases.transform.GetChild(2).transform.position = aux;
        Vector3 aux2 = gameObject.GetComponent<GameManager>().Bases.transform.GetChild(1).transform.position;
        gameObject.GetComponent<GameManager>().Bases.transform.GetChild(1).transform.position = gameObject.GetComponent<GameManager>().Bases.transform.GetChild(3).transform.position;
        gameObject.GetComponent<GameManager>().Bases.transform.GetChild(3).transform.position = aux2; 
    }
    private void EventFastPlayer() { 
        for(int i=0;i<4;i++) {
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(i).GetComponent<Movement>().movementSpeed *= MoveSpeedPlus;
        }
    }
    IEnumerator CooldownEvent() {
        yield return new WaitForSeconds(CooldownDoEvento);
        Permition = true;
    }
    private void ChooseEvent() {
        Permition = false;
        int GetEventNumber = Random.Range(1,3);
        RandomEventCanvas.SetActive(true);
        switch(GetEventNumber) {
            case 1:
                EventChangeBase();
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: " + "Bases Trocadas";
                break;
            case 2:
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: " + "Velocidade Aumentada";
                EventFastPlayer();
                break;
        }
        StartCoroutine(RemoveCanvas());
        StartCoroutine(CooldownEvent());
    }
    IEnumerator RemoveCanvas() {
        yield return new WaitForSeconds(2);
        RandomEventCanvas.SetActive(false);
    }
}
