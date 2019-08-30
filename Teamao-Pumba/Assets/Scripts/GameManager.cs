using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Script para gerenciamento do jogo 

Author: Vinny
*/
public class GameManager : MonoBehaviour
{
    public GameObject Players; // Os jogadores
    public GameObject HowManyPlayers; // O canvas contendo quantos jogadores
    public GameObject CharacterSelect; // O canvas contendo a seleção de personagem
    public GameObject VictoryCanvas; // O canvas de fim de jogo
    public Text ResultText; // Texto do resultado da partida
    public Text ErrorText; // Um texto de erro caso o jogo comece sem escolher a quantidade de jogadores
    public Text CountdownTimer; // Countdown antes de comecar o jogo
    private bool PlayersSelected;
    private bool CountdownAcabou;
    private int PontosdeVitoria;
    public int VictoryByPoint;
    private float tempo = 15;
    private float Countdown = 4;
     public void TwoPlayer() { // função para dois players
        Players.transform.GetChild(0).gameObject.SetActive(true);
        Players.transform.GetChild(1).gameObject.SetActive(true);
        Players.transform.GetChild(2).gameObject.SetActive(false);
        Players.transform.GetChild(3).gameObject.SetActive(false);
        PlayersSelected = true;
    }
     public void ThreePlayer() { // função para três players
        Players.transform.GetChild(0).gameObject.SetActive(true);
        Players.transform.GetChild(1).gameObject.SetActive(true);
        Players.transform.GetChild(2).gameObject.SetActive(true);
        Players.transform.GetChild(3).gameObject.SetActive(false);
        PlayersSelected = true;
    }
     public void FourPlayer() { // função para quatro players
        Players.transform.GetChild(0).gameObject.SetActive(true);
        Players.transform.GetChild(1).gameObject.SetActive(true);
        Players.transform.GetChild(2).gameObject.SetActive(true);
        Players.transform.GetChild(3).gameObject.SetActive(true);
        PlayersSelected = true;
    }
    public void Next() { // Vai para a tela de seleção de personagem
        if(PlayersSelected) {
            HowManyPlayers.SetActive(false);
            CharacterSelect.SetActive(true);
        }
        else {
            ErrorText.text = "Selecione o número de jogadores antes de começar a partida!";
        }
    }
    public void Previous() { // Volta para a tela de numero de jogadores
        PlayersSelected = false;
        HowManyPlayers.SetActive(true);
        CharacterSelect.SetActive(false);
    }
    public void PlayGame() { // Começa o jogo
        CharacterSelect.transform.parent.gameObject.SetActive(false);
    }
    void Start()
    {
        CountdownAcabou = false;
        PlayersSelected = false;
        HowManyPlayers.SetActive(true);
        CharacterSelect.SetActive(false);
        VictoryCanvas.SetActive(false);
        CountdownTimer.gameObject.SetActive(false);
        Players.transform.GetChild(0).gameObject.SetActive(false);
        Players.transform.GetChild(1).gameObject.SetActive(false);
        Players.transform.GetChild(2).gameObject.SetActive(false);
        Players.transform.GetChild(3).gameObject.SetActive(false); 
    }
    void Update()
    {
        if(CountdownAcabou) {
            tempo -= Time.deltaTime;
        }
        if(PlayersSelected) {
            ErrorText.text = "";
        }
        for(int i = 0;i < 4;i++) { // Verifica o fim do jogo
            if(Players.transform.GetChild(i).GetComponent<PointSystem>().RealPoints >= VictoryByPoint + SegundoMelhor() || tempo < 0) {
                VictoryCanvas.SetActive(true);
                ResultText.text = "Resultado\n\nPlayer 1: " + Players.transform.GetChild(0).GetComponent<PointSystem>().RealPoints + "\n\n";
                ResultText.text += "Player 2: " + Players.transform.GetChild(1).GetComponent<PointSystem>().RealPoints + "\n\n";
                if(Players.transform.GetChild(2).gameObject.activeSelf) {
                    ResultText.text += "Player 3: " + Players.transform.GetChild(2).GetComponent<PointSystem>().RealPoints + "\n\n";
                    if(Players.transform.GetChild(3).gameObject.activeSelf) {
                        ResultText.text += "Player 4: " + Players.transform.GetChild(3).GetComponent<PointSystem>().RealPoints;
                    }
                }
                if(!empate()) {
                    ResultText.text += "\n\n\n Winner: " + MaiorValor();
                }
                else {
                    ResultText.text += "\n\n\n Empate!";
                }
            }
        }

    }
    void FixedUpdate()
    {
        if(!CharacterSelect.transform.parent.gameObject.activeSelf) {
            CountdownTimer.gameObject.SetActive(true);
            Debug.Log(Countdown);
            Countdown -= Time.deltaTime;
            CountdownTimer.text = Mathf.RoundToInt((Countdown - 1)).ToString();
            if(Countdown - 1 <= 1) {
                CountdownTimer.text = "Start!";
            }
            if(Countdown - 1 <= 0) {
                CountdownTimer.text = Mathf.RoundToInt(tempo).ToString();
                CountdownAcabou = true;
                if(tempo < 0) {
                    CountdownTimer.text = "Finish!";
                }
            }
        }
       
    }

    private string MaiorValor() { // Pega o Melhor jogador e devolve seu nome
        string nome = "";
        int maior = 0;
        if(Players.transform.GetChild(0).GetComponent<PointSystem>().RealPoints > maior) {
            maior = Players.transform.GetChild(0).GetComponent<PointSystem>().RealPoints;
            nome = "Player 1";
        }
        if(Players.transform.GetChild(1).GetComponent<PointSystem>().RealPoints > maior) {
            maior = Players.transform.GetChild(0).GetComponent<PointSystem>().RealPoints;
            nome = "Player 2";
        }
        if(Players.transform.GetChild(2).GetComponent<PointSystem>().RealPoints > maior) {
            maior = Players.transform.GetChild(0).GetComponent<PointSystem>().RealPoints;
            nome = "Player 3";
        }
        if(Players.transform.GetChild(3).GetComponent<PointSystem>().RealPoints > maior) {
            maior = Players.transform.GetChild(0).GetComponent<PointSystem>().RealPoints;
            nome = "Player 4";
        }
        return nome;
    }
    private int SegundoMelhor() { // Pega o Segundo melhor jogador
        int sm = 0;
        List<GameObject> list = new List<GameObject>();
        list.Add(Players.transform.GetChild(0).gameObject);
        list.Add(Players.transform.GetChild(1).gameObject);
        list.Add(Players.transform.GetChild(2).gameObject);
        list.Add(Players.transform.GetChild(3).gameObject);
        foreach(GameObject g in list) {
            if(g.GetComponent<PointSystem>().RealPoints > sm) {
                sm = g.GetComponent<PointSystem>().RealPoints;
            } 
        }
        foreach(GameObject g in list) {
            if(g.GetComponent<PointSystem>().RealPoints == sm) {
                list.Remove(g);
                sm = 0;
                break;
            } 
        }
        foreach(GameObject g in list) {
            if(g.GetComponent<PointSystem>().RealPoints > sm) {
                sm = g.GetComponent<PointSystem>().RealPoints;
            } 
        }
        return sm;
    }
    private bool empate() { // Verifica se houve empate no final da partida
        int sm = 0;
        List<GameObject> list = new List<GameObject>();
        list.Add(Players.transform.GetChild(0).gameObject);
        list.Add(Players.transform.GetChild(1).gameObject);
        list.Add(Players.transform.GetChild(2).gameObject);
        list.Add(Players.transform.GetChild(3).gameObject);
        foreach(GameObject g in list) {
            if(g.GetComponent<PointSystem>().RealPoints > sm) {
                sm = g.GetComponent<PointSystem>().RealPoints;
            } 
        }
        if(sm == SegundoMelhor()) {
            return true;
        }
        return false;
    }
}