using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*Script Feito para fazer funções de troca de cena


Author: Vinny
Homsi brincou também*/
public class SceneJumper : MonoBehaviour
{
    public AudioSource Arena;
    public AudioSource Chant;

    public void GoArena()
    {
        if(Arena != null)
        { Arena.enabled = true; }
        SceneManager.LoadScene("Arena", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
    public void GoCredits()
    {
        if (Chant != null)
        { Chant.enabled = true; }
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
    public void GoMenu()
    {
        if (Chant != null)
        {Chant.enabled = false;}
        if (Arena != null)
        { Arena.enabled = false; }
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        if (Arena != null)
        {
            Arena.enabled = false;
        }
        Application.Quit();
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void GoStartGame()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
}
