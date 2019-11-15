using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settngs", menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public int playerNumbers {get; set;}
    private string[] personagens = { "", "", "", ""};


    public void setPlayerChoice(int jogador, string personagem)
    {
        personagens[jogador] = personagem;
    }

    public string getPlayerChoice(int jogador)
    {
        return personagens[jogador];
    }

    public bool allPlayersReady()
    {
        for(int i = 0; i < playerNumbers; i++)
        {
            if (personagens[i] == "")
                return false;
        }
        return true;
    }

    public void reset()
    {
		personagens = { "", "", "", ""};
		playerNumbers = -1;
    }
}
