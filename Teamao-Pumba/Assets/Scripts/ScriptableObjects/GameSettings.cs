using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settngs", menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public int playerNumbers;
    private int[] personagens = { -1, -1, -1, -1 };

    public void setPlayerChoice(int jogador, int personagem)
    {
        personagens[jogador] = personagem;
    }

    public int getPlayerChoise(int jogador)
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
}
