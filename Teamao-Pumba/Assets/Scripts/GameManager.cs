using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Players;
    public GameObject Settings;
    public GameObject ErrorText;
    private bool PlayersSelected;
     public void TwoPlayer() {
        Players.transform.GetChild(0).gameObject.SetActive(true);
        Players.transform.GetChild(1).gameObject.SetActive(true);
        Players.transform.GetChild(2).gameObject.SetActive(false);
        Players.transform.GetChild(3).gameObject.SetActive(false);
        PlayersSelected = true;
    }
     public void ThreePlayer() {
        Players.transform.GetChild(0).gameObject.SetActive(true);
        Players.transform.GetChild(1).gameObject.SetActive(true);
        Players.transform.GetChild(2).gameObject.SetActive(true);
        Players.transform.GetChild(3).gameObject.SetActive(false);
        PlayersSelected = true;
    }
     public void FourPlayer() {
        Players.transform.GetChild(0).gameObject.SetActive(true);
        Players.transform.GetChild(1).gameObject.SetActive(true);
        Players.transform.GetChild(2).gameObject.SetActive(true);
        Players.transform.GetChild(3).gameObject.SetActive(true);
        PlayersSelected = true;
    }
    public void PlayGame() {
        if(PlayersSelected) {
            Settings.SetActive(false);
        }
        else {
            ErrorText.SetActive(true);
        }
        
    }


    void Start()
    {
        PlayersSelected = false;
        Settings.SetActive(true);
        Players.transform.GetChild(0).gameObject.SetActive(false);
        Players.transform.GetChild(1).gameObject.SetActive(false);
        Players.transform.GetChild(2).gameObject.SetActive(false);
        Players.transform.GetChild(3).gameObject.SetActive(false);
    }

    
    void Update()
    {
        if(PlayersSelected) {
            ErrorText.SetActive(false);
        }
    }
}
