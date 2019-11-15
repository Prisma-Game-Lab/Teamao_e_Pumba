using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settngs", menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public int playerNumbers {get; set;}
    private int[] personagens = { -1, -1, -1, -1 };


    public void setPlayerChoice(int jogador, int personagem)
    {
        personagens[jogador] = personagem;
    }

    public int getPlayerChoice(int jogador)
    {
        return personagens[jogador];
    }

    public bool allPlayersReady()
    {
        for(int i = 0; i < playerNumbers; i++)
        {
            if (personagens[i] == -1)
                return false;
        }
        return true;
    }

    public void reset()
    {
		personagens = { -1, -1, -1, -1 };
		playerNumbers = -1;
    }
}
