using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEvent : MonoBehaviour
{
    public GameObject RandomEventCanvas;
    public GameObject Arena;
    public float Probabilidade;
    public int CooldownDoEvento;
    public float MoveSpeedPlus;
    public float RotateSpeed;
    private float NumeroGerado;
    private bool RotatePermition = false;
    private bool Permition = true;
    public float TempoVar;
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
        if(RotatePermition) {
            Arena.transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime);
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
    private void EventMoreLessTime() {
        int GetEventNumber = Random.Range(1,3);
        if(GetEventNumber == 1) {
            RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Tempo Aumentado Em " + TempoVar + " Segundos";
            gameObject.GetComponent<GameManager>().tempo += TempoVar;
        }
        if(GetEventNumber == 2 &&  gameObject.GetComponent<GameManager>().tempo - TempoVar > 10) {
            RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Tempo Diminuido Em " + TempoVar + " Segundos";
            gameObject.GetComponent<GameManager>().tempo -= TempoVar;
        }
        else {
            RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Tempo Aumentado Em " + TempoVar + " Segundos";
            gameObject.GetComponent<GameManager>().tempo += TempoVar;
        }
        
    }
    private void EventRotatingStage() {
        RotatePermition = true;
        RotateSpeed *= RotateSpeed;
    }
    IEnumerator CooldownEvent() {
        yield return new WaitForSeconds(CooldownDoEvento);
        Permition = true;
    }
    private void ChooseEvent() {
        Permition = false;
        int GetEventNumber = Random.Range(1,5);
        RandomEventCanvas.SetActive(true);
        switch(GetEventNumber) {
            case 1:
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Bases Trocadas";
                EventChangeBase();
                break;
            case 2:
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Velocidade Aumentada";
                EventFastPlayer();
                break;
            case 3:
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: ";
                EventMoreLessTime();
                break;
            case 4:
                if(!RotatePermition) {
                    RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Rotação do Estágio Ativada";
                }
                else {
                    RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Rotação do Estágio Aumentada";
                }
                EventRotatingStage();
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
