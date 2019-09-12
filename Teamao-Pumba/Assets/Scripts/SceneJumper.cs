using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*Script Feito para fazer funções de troca de cena


Author: Vinny */
public class SceneJumper : MonoBehaviour
{
    public void GoArena() {
        SceneManager.LoadScene("Arena",LoadSceneMode.Single);
        Debug.Log("ehehehehehe");
        Time.timeScale = 1f;
    }
    public void GoCredits() {
        SceneManager.LoadScene("Credits",LoadSceneMode.Single);
    }
    public void GoMenu() {
        SceneManager.LoadScene("Menu",LoadSceneMode.Single);
        Debug.Log("Lmao");
        Time.timeScale = 1f;
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
