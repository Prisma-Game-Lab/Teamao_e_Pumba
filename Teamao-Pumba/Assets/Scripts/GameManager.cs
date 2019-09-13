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
    public GameObject Bases; // As bases
    public GameObject HowManyPlayers; // O canvas contendo quantos jogadores
    public GameObject CharacterSelect; // O canvas contendo a seleção de personagem
    public GameObject SettingsCanvas; // O canvas contendo as Settings do jogo
    public GameObject VictoryCanvas; // O canvas de fim de jogo
    public GameObject PointsCanvas; // O canvas de Pontos
    public GameObject CarryCanvas; // O canvas dos itens sendo carregados
    public Text ResultText; // Texto do resultado da partida
    public Text ErrorText; // Um texto de erro caso o jogo comece sem escolher a quantidade de jogadores
    public Text CountdownTimer; // Countdown antes de comecar o jogo
    public Text Timer;
    public Image TimerCircle;
    private bool PlayersSelected;
    private bool CountdownAcabou;
    private int VictoryByPoint = 999;
    [HideInInspector]
    public float tempo = 999;
    [HideInInspector]
    public float Countdown = 4;
    private  float movespeed;
    private float MaxTimer = 999;
    private bool movizin = true;
     public void TwoPlayer() { // função para dois players
        gameObject.transform.GetComponent<ButtonSelect>().HowManyPlayers = 2;
        Players.transform.GetChild(2).gameObject.SetActive(false);
        Players.transform.GetChild(3).gameObject.SetActive(false);
        PlayersSelected = true;
        ErrorText.text = "";
    }
     public void ThreePlayer() { // função para três players
     gameObject.transform.GetComponent<ButtonSelect>().HowManyPlayers = 3;
        Players.transform.GetChild(2).gameObject.SetActive(true);
        Players.transform.GetChild(3).gameObject.SetActive(false);
        PlayersSelected = true;
        ErrorText.text = "";
    }
     public void FourPlayer() { // função para quatro players
     gameObject.transform.GetComponent<ButtonSelect>().HowManyPlayers = 4;
        Players.transform.GetChild(2).gameObject.SetActive(true);
        Players.transform.GetChild(3).gameObject.SetActive(true);
        PlayersSelected = true;
        ErrorText.text = "";
    }
    public void TempoDeJogo(int Segundos) {
        tempo = Segundos;
        MaxTimer = Segundos;
        ErrorText.text = "";
    }
    public void SetVictoryByPoint(int Pontos) {
        VictoryByPoint = Pontos;
        ErrorText.text = "";
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
    public void Next2() { // Vai para a tela de Settings
        if(Next2Helper()) {
            CharacterSelect.SetActive(false);
            SettingsCanvas.SetActive(true);
            ErrorText.text = "";
        }
        else {
            ErrorText.text = "Espere até todos os players terem escolhido seu personagem!";
        }
        
    }
    private bool Next2Helper() {
        for(int i =0; i < transform.GetComponent<ButtonSelect>().HowManyPlayers; i++) {
            if(!transform.GetComponent<ButtonSelect>().PlayersWithCharacter[i]) {
                return false;
            }
        }
        return true;
    }
    public void Previous() { // Volta para a tela de numero de jogadores
        for(int i =0; i < transform.GetComponent<ButtonSelect>().HowManyPlayers; i++) {
            transform.GetComponent<ButtonSelect>().PlayersWithCharacter[i] = false;
        }
        PlayersSelected = false;
        HowManyPlayers.SetActive(true);
        CharacterSelect.SetActive(false);
        ErrorText.text = "";
    }
    public void Previous2() { // Volta para a tela de seleção de personagem
        for(int i =0; i < transform.GetComponent<ButtonSelect>().HowManyPlayers; i++) {
            transform.GetComponent<ButtonSelect>().PlayersWithCharacter[i] = false;
        }
        CharacterSelect.SetActive(true);
        SettingsCanvas.SetActive(false);
        tempo = 999;
        gameObject.GetComponent<RandomEvent>().Probabilidade = 0;
        VictoryByPoint = 999;
        ErrorText.text = "";
    }

    public void PlayGame() { // Começa o jogo
        if(tempo == 999) {
            ErrorText.text = "Selecione quanto tempo de jogo antes de começar a partida!";
        }
        else {
            if(gameObject.GetComponent<RandomEvent>().Probabilidade == 999999) {
               ErrorText.text = "Selecione a probabilidade de um evento ocorrer antes de começar a partida!";
            }
            else {
                if(VictoryByPoint == 999) {
                    ErrorText.text = "Selecione a pontuação para obter a vitória antes de começar a partida!";
                }
                else {
                    if(VictoryByPoint == 999999 && tempo == 999999) {
                        ErrorText.text = "Vitoria por Ponto Desligado e Duração da Partida Infinita, O jogo não tem como acabar!";
                    }
                    else {
                        CharacterSelect.transform.parent.gameObject.SetActive(false);
                        for(int i=0;i<4;i++) {
                            if(Players.transform.GetChild(i).gameObject.activeSelf) {
                                PointsCanvas.transform.GetChild(i).gameObject.SetActive(true);
                                Bases.transform.GetChild(i).gameObject.SetActive(true);
                                CarryCanvas.transform.GetChild(i).gameObject.SetActive(true);
                                SetCharacterImage();
                            }
                        }
                    }
                }
            }
        }
    }
    void Start()
    {
        CountdownAcabou = false;
        PlayersSelected = false;
        HowManyPlayers.SetActive(true);
        CharacterSelect.SetActive(false);
        VictoryCanvas.SetActive(false);
        CountdownTimer.gameObject.SetActive(false);
        SettingsCanvas.SetActive(false);
        movespeed = Players.transform.GetChild(0).transform.GetChild(0).GetComponent<MovimentAxis>().movementSpeed;
        for(int i=0;i<4;i++) {
            PointsCanvas.transform.GetChild(i).gameObject.SetActive(false);
            Bases.transform.GetChild(i).gameObject.SetActive(false);
            CarryCanvas.transform.GetChild(i).gameObject.SetActive(false);
            Players.transform.GetChild(0).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed = 0;
            Players.transform.GetChild(1).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed = 0;
            Players.transform.GetChild(2).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed = 0;
            Players.transform.GetChild(3).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed = 0;
        }
        Players.transform.GetChild(0).gameObject.SetActive(true);
        Players.transform.GetChild(1).gameObject.SetActive(true);
        Players.transform.GetChild(2).gameObject.SetActive(false);
        Players.transform.GetChild(3).gameObject.SetActive(false);  
    }
    void Update()
    {
        if(CountdownAcabou && tempo > 0) {
            if(tempo != 999999) {
                tempo -= Time.deltaTime;
                TimerCircle.fillAmount = tempo/MaxTimer;
            }
            if(movizin) {
                for(int i=0;i<4;i++) {
                    Players.transform.GetChild(0).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed = movespeed;
                    Players.transform.GetChild(1).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed = movespeed;
                    Players.transform.GetChild(2).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed = movespeed;
                    Players.transform.GetChild(3).transform.GetChild(i).GetComponent<MovimentAxis>().movementSpeed = movespeed;
                }
                movizin = false;
            }
        }
        for(int i = 0;i < 4;i++) { // Verifica o fim do jogo
            if(Players.transform.GetChild(i).GetComponent<PointSystemPai>().RealPoints >= VictoryByPoint + SegundoMelhor() || tempo < 0) {
                StartCoroutine(ShowVictoryCanvas());
                CountdownTimer.gameObject.SetActive(true);
                CountdownTimer.text = "Finish!";
                ResultText.text = "Resultado\n\nPlayer 1: " + Players.transform.GetChild(0).GetComponent<PointSystemPai>().RealPoints + "\n\n";
                ResultText.text += "Player 2: " + Players.transform.GetChild(1).GetComponent<PointSystemPai>().RealPoints + "\n\n";
                if(Players.transform.GetChild(2).gameObject.activeSelf) {
                    ResultText.text += "Player 3: " + Players.transform.GetChild(2).GetComponent<PointSystemPai>().RealPoints + "\n\n";
                    if(Players.transform.GetChild(3).gameObject.activeSelf) {
                        ResultText.text += "Player 4: " + Players.transform.GetChild(3).GetComponent<PointSystemPai>().RealPoints;
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
        ShowPoints();
    }
    void FixedUpdate()
    {
        if(!CharacterSelect.transform.parent.gameObject.activeSelf) {
            CountdownTimer.gameObject.SetActive(true);
            Countdown -= Time.deltaTime;
            CountdownTimer.text = Mathf.RoundToInt((Countdown - 1)).ToString();
            if(Countdown - 1 <= 1 && tempo > 0) {
                CountdownTimer.text = "Start!";
                CountdownAcabou = true;
                Timer.gameObject.SetActive(true);
                if(tempo != 999999) {
                    Timer.text = Mathf.RoundToInt(tempo).ToString();
                }
                else {
                    Timer.text = "∞";
                }
            }
            if(Countdown - 1 <= 0 && tempo > 0) {
                CountdownTimer.gameObject.SetActive(false);
            }
        }
    }

    private string MaiorValor() { // Pega o Melhor jogador e devolve seu nome
        string nome = "";
        int maior = 0;
        if(Players.transform.GetChild(0).GetComponent<PointSystemPai>().RealPoints > maior) {
            maior = Players.transform.GetChild(0).GetComponent<PointSystemPai>().RealPoints;
            nome = "Player 1";
        }
        if(Players.transform.GetChild(1).GetComponent<PointSystemPai>().RealPoints > maior) {
            maior = Players.transform.GetChild(1).GetComponent<PointSystemPai>().RealPoints;
            nome = "Player 2";
        }
        if(Players.transform.GetChild(2).GetComponent<PointSystemPai>().RealPoints > maior) {
            maior = Players.transform.GetChild(2).GetComponent<PointSystemPai>().RealPoints;
            nome = "Player 3";
        }
        if(Players.transform.GetChild(3).GetComponent<PointSystemPai>().RealPoints > maior) {
            maior = Players.transform.GetChild(3).GetComponent<PointSystemPai>().RealPoints;
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
            if(g.GetComponent<PointSystemPai>().RealPoints > sm) {
                sm = g.GetComponent<PointSystemPai>().RealPoints;
            } 
        }
        foreach(GameObject g in list) {
            if(g.GetComponent<PointSystemPai>().RealPoints == sm) {
                list.Remove(g);
                sm = 0;
                break;
            } 
        }
        foreach(GameObject g in list) {
            if(g.GetComponent<PointSystemPai>().RealPoints > sm) {
                sm = g.GetComponent<PointSystemPai>().RealPoints;
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
            if(g.GetComponent<PointSystemPai>().RealPoints > sm) {
                sm = g.GetComponent<PointSystemPai>().RealPoints;
            } 
        }
        if(sm == SegundoMelhor()) {
            return true;
        }
        return false;
    }
    private void ShowPoints() {
        for(int i=0;i<4;i++) {
            PointsCanvas.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = Players.transform.GetChild(i).GetComponent<PointSystemPai>().RealPoints.ToString();
            CarryCanvas.transform.GetChild(i).GetComponent<Text>().text = Players.transform.GetChild(i).GetComponent<PointSystemPai>().VirtualPoints.ToString();
            if(Players.transform.GetChild(i).GetComponent<PointSystemPai>().VirtualPoints == Players.transform.GetChild(i).GetComponent<PointSystemPai>().MaxItem) {
                CarryCanvas.transform.GetChild(i+4).gameObject.SetActive(true);
            }
            else {
                CarryCanvas.transform.GetChild(i+4).gameObject.SetActive(false);
            }
        }
    }

    IEnumerator ShowVictoryCanvas() {
        yield return new WaitForSeconds(1);
         VictoryCanvas.SetActive(true);
         Time.timeScale = 0f;
    }

    private void SetCharacterImage() {
        int indice1 = 0;
        int indice2 = 0;
        int indice3 = 0;
        int indice4 = 0;
        int i;
        for(i=0;i < 4; i++) {
            if(Players.transform.GetChild(0).transform.GetChild(i).gameObject.activeSelf) {
                indice1 = i;
            }
        }
        for(i=0;i < 4; i++) {
            if(Players.transform.GetChild(1).transform.GetChild(i).gameObject.activeSelf) {
                indice2 = i;
            }
        }
        for(i=0;i < 4; i++) {
            if(Players.transform.GetChild(2).transform.GetChild(i).gameObject.activeSelf) {
                indice3 = i;
            }
        }
        for(i=0;i < 4; i++) {
            if(Players.transform.GetChild(3).transform.GetChild(i).gameObject.activeSelf) {
                indice4 = i;
            }
        }
        PointsCanvas.transform.GetChild(0).transform.GetChild(indice1+1).gameObject.SetActive(true);
        PointsCanvas.transform.GetChild(1).transform.GetChild(indice2+1).gameObject.SetActive(true);
        PointsCanvas.transform.GetChild(2).transform.GetChild(indice3+1).gameObject.SetActive(true);
        PointsCanvas.transform.GetChild(3).transform.GetChild(indice4+1).gameObject.SetActive(true);
        
    }
}