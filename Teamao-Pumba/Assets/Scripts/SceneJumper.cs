using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJumper : MonoBehaviour
{
    public void GoArena() {
        SceneManager.LoadScene("Arena",LoadSceneMode.Single);
    }
    public void GoCredits() {
        SceneManager.LoadScene("Credits",LoadSceneMode.Single);
    }
    public void QuitGame() {
        Application.Quit();
    }
   
}
