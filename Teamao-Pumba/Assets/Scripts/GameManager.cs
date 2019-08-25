using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Script para gerenciamento do jogo 

Author: Vinny*/
public class GameManager : MonoBehaviour
{
    public GameObject Players; // Os jogadores
    public GameObject HowManyPlayers; // O canvas contendo quantos jogadores
    public GameObject CharacterSelect; // O canvas contendo a seleção de personagem
    public Text ErrorText; // Um texto de erro caso o jogo comece sem escolher a quantidade de jogadores
    private bool PlayersSelected;
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
        PlayersSelected = false;
        HowManyPlayers.SetActive(true);
        CharacterSelect.SetActive(false);
        Players.transform.GetChild(0).gameObject.SetActive(false);
        Players.transform.GetChild(1).gameObject.SetActive(false);
        Players.transform.GetChild(2).gameObject.SetActive(false);
        Players.transform.GetChild(3).gameObject.SetActive(false);
    }

    
    void Update()
    {
        if(PlayersSelected) {
            ErrorText.text = "";
        }
    }
}
