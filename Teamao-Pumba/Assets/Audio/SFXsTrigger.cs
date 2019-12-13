using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXsTrigger : MonoBehaviour
{

    public AudioSource UI;
    public AudioSource Tuco;
    public AudioSource Lico;
    public AudioSource Capi;
    public AudioSource Jess;


    public void PlaySFX (int index)
    {
        switch (index)
        {
            case 1:
                UI.Play();
                break;
            case 2:
                Tuco.Play();
                break;
            case 3:
                Lico.Play();
                break;
            case 4:
                Capi.Play();
                break;
            default:
                Jess.Play();
                break;
        }
    }


}
