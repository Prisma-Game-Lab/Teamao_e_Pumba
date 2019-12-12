using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject howManyPlayers;
    public GameObject characterSelect;
    public GameObject settings;

    public GameSettings gameSettings;

    public Text ErrorText;
    private bool isPlayerNumbersSelected;
    public List<Image> UIPlayers;

    void Awake()
    {
        howManyPlayers.SetActive(true);
        characterSelect.SetActive(false);
        settings.SetActive(false);
        // gameSettings.reset();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TwoPlayers()
    {
        gameSettings.playerNumbers = 2;
        isPlayerNumbersSelected = true;
        UIPlayers[0].gameObject.SetActive(true);
        UIPlayers[1].gameObject.SetActive(true);
        UIPlayers[2].gameObject.SetActive(false);
        UIPlayers[3].gameObject.SetActive(false);
        GoToCharacterSelect();


    }
    public void ThreePlayers()
    {
        gameSettings.playerNumbers = 3;
        isPlayerNumbersSelected = true;
        UIPlayers[0].gameObject.SetActive(true);
        UIPlayers[1].gameObject.SetActive(true);
        UIPlayers[2].gameObject.SetActive(true);
        UIPlayers[3].gameObject.SetActive(false);
        GoToCharacterSelect();
    }
    public void FourPlayers()
    {
        gameSettings.playerNumbers = 4;
        isPlayerNumbersSelected = true;
        UIPlayers[0].gameObject.SetActive(true);
        UIPlayers[1].gameObject.SetActive(true);
        UIPlayers[2].gameObject.SetActive(true);
        UIPlayers[3].gameObject.SetActive(true);
        GoToCharacterSelect();
    }
    private void GoToCharacterSelect()
    { // Vai para a tela de seleção de personagem
        if (isPlayerNumbersSelected)
        {
            howManyPlayers.SetActive(false);
            characterSelect.SetActive(true);
            ResetaCoordenada();
        }
        else
        {
            ErrorText.text = "Selecione o número de jogadores antes de começar a partida!";
        }
    }
    public void GoToGameSettings()
    {
        if (Next2Helper())
        {
            characterSelect.SetActive(false);
            settings.SetActive(true);
            ErrorText.text = "";
            ResetaCoordenada();
        }
        else
        {
            ErrorText.text = "Espere até todos os players terem escolhido seu personagem!";
        }
    }
    private void ResetaCoordenada()
    {
        for (int i = 0; i < transform.GetComponent<ButtonSelect>().CoordenadaPlayers.Count; i++)
        {
            transform.GetComponent<ButtonSelect>().CoordenadaPlayers[i] = 0;
        }
    }
    private bool Next2Helper()
    {
        // for(int i =0; i < transform.GetComponent<ButtonSelect>().HowManyPlayers; i++) {
        //     if(!transform.GetComponent<ButtonSelect>().PlayersWithCharacter[i]) {
        //         return false;
        //     }
        // }
        return true;
    }
    public void GoBackToCharacterSelect()
    {
        ResetaCoordenada();
        settings.SetActive(false);
        characterSelect.SetActive(true);
        ErrorText.text = "";
    }

    public void GoBackToHowManyPlayers()
    {
        ResetaCoordenada();
        for (int i = 1; i < gameSettings.playerNumbers; i++)
        {
            List<Image> selectPlayers = GetComponent<ButtonSelect>().SelectPlayers;
            transform.GetComponent<ButtonSelect>().PlayersWithCharacter[i] = false;
            UIPlayers[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
            UIPlayers[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
            UIPlayers[i].gameObject.transform.GetChild(2).gameObject.SetActive(false);
            selectPlayers[i].gameObject.SetActive(false);
            selectPlayers[i].gameObject.SetActive(false);
            selectPlayers[i].gameObject.SetActive(false);


        }

        gameSettings.playerNumbers = 0;
        isPlayerNumbersSelected = false;
        howManyPlayers.SetActive(true);
        characterSelect.SetActive(false);
        ErrorText.text = "";
    }

}
