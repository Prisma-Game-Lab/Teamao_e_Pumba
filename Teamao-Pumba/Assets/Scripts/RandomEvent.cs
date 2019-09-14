using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEvent : MonoBehaviour
{
    public GameObject Players;
    public GameObject RandomEventCanvas;
    public GameObject Arena;
    public GameObject Camera;
    [HideInInspector]
    public float Probabilidade = 999999;
    public int DuracaoDoEvento;
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
                StartCoroutine(ChooseEvent());
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
        int GetRandomNumber = Random.Range(1,4);
        Vector3 aux = gameObject.GetComponent<GameManager>().Bases.transform.GetChild(0).gameObject.transform.position;
        Vector3 aux2 = aux;
        int i;
        gameObject.GetComponent<GameManager>().Bases.transform.GetChild(0).gameObject.transform.position = gameObject.GetComponent<GameManager>().Bases.transform.GetChild(GetRandomNumber).gameObject.transform.position;
        gameObject.GetComponent<GameManager>().Bases.transform.GetChild(GetRandomNumber).gameObject.transform.position = aux;
        for(i=1;i<4;i++) {
            if(i != GetRandomNumber) {
                aux2 = gameObject.GetComponent<GameManager>().Bases.transform.GetChild(i).gameObject.transform.position;
                break;
            }
        }
        for(int j=1;j<4;j++) {
                if(j != i && j != GetRandomNumber) {
                    gameObject.GetComponent<GameManager>().Bases.transform.GetChild(i).gameObject.transform.position = gameObject.GetComponent<GameManager>().Bases.transform.GetChild(j).gameObject.transform.position;
                    gameObject.GetComponent<GameManager>().Bases.transform.GetChild(j).gameObject.transform.position = aux2;
                }
            } 
    }
    private void EventFastPlayer() { 
        for(int i=0;i<4;i++) {
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(0).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= MoveSpeedPlus;
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(1).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= MoveSpeedPlus;
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(2).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= MoveSpeedPlus;
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(3).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= MoveSpeedPlus;
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
    private void EventDoubleItemSpawn() => gameObject.GetComponent<ItemSpawn>().Item_qtd *= 2;
    
    IEnumerator EventInvertMovement() {
        for(int i=0;i<4;i++) {
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(0).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= -1;
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(1).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= -1;
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(2).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= -1;
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(3).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= -1;
        }
        yield return new WaitForSeconds(DuracaoDoEvento);
        for(int i=0;i<4;i++) {
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(0).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= -1;
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(1).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= -1;
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(2).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= -1;
            gameObject.GetComponent<GameManager>().Players.transform.GetChild(3).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed *= -1;
        }
    }
    IEnumerator EventInvertCamera() { 
        int GetEventNumber = Random.Range(1,4);
        switch(GetEventNumber) {
            case 1:
                Camera.transform.Rotate(0,0,90);
                yield return new WaitForSeconds(DuracaoDoEvento);
                Camera.transform.Rotate(0,0,360-90);
                break;
            case 2:
                Camera.transform.Rotate(0,0,180);
                yield return new WaitForSeconds(DuracaoDoEvento);
                Camera.transform.Rotate(0,0,360-180);
                break;
            case 3:
                Camera.transform.Rotate(0,0,270);
                yield return new WaitForSeconds(DuracaoDoEvento);
                Camera.transform.Rotate(0,0,360-270);
                break;     
        }
    }
    IEnumerator CooldownEvent() {
        yield return new WaitForSeconds(CooldownDoEvento);
        Permition = true;
    }
    IEnumerator ChooseEvent() {
        Permition = false;
        int GetEventNumber = Random.Range(1,8);
        RandomEventCanvas.SetActive(true);
        StartCoroutine(BlinkEventText());
        switch(GetEventNumber) {
            case 1:
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Bases Trocadas";
                yield return new WaitForSeconds(1);
                EventChangeBase();
                break;
            case 2:
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Velocidade Aumentada";
                yield return new WaitForSeconds(1);
                EventFastPlayer();
                break;
            case 3:
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Bases Trocadas";
                yield return new WaitForSeconds(1);
                EventChangeBase();
                break;
            case 4:
                if(!RotatePermition) {
                    RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Rotação do Estágio Ativada";
                }
                else {
                    RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Rotação do Estágio Aumentada";
                }
                yield return new WaitForSeconds(1);
                EventRotatingStage();
                break;
            case 5:
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Camera Girou";
                yield return new WaitForSeconds(1);
                StartCoroutine(EventInvertCamera());
                break;
            case 6:
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Movimentação Invertida";
                yield return new WaitForSeconds(1);
                StartCoroutine(EventInvertMovement());
                break;
            case 7:
                RandomEventCanvas.transform.GetChild(0).GetComponent<Text>().text = "Evento: Quantidade de Itens Dobrado";
                yield return new WaitForSeconds(1);
                EventDoubleItemSpawn();;
                break;

        }
        StartCoroutine(RemoveCanvas());
        StartCoroutine(CooldownEvent());
    }
    IEnumerator RemoveCanvas() {
        yield return new WaitForSeconds(DuracaoDoEvento);
        RandomEventCanvas.SetActive(false);
    }
    IEnumerator BlinkEventText() {
        int i = 0;
        while(i < 5) {
            RandomEventCanvas.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            RandomEventCanvas.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            i++;
        }   
    }
    public void ChanceDeEvento(float chance) {
        Probabilidade = chance;
        gameObject.GetComponent<GameManager>().ErrorText.text = "";
    }
}
