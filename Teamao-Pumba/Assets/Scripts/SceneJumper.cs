using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*Script Feito para fazer funções de troca de cena


Author: Vinny
Homsi brincou também*/
public class SceneJumper : MonoBehaviour
{
   // public AudioSource Arena;
   // public AudioSource Chant;

    public void GoArena()
    {
        SceneManager.LoadScene("Arena", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
    public void GoCredits()
    {

        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
    public void GoMenu()
    {

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {

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
