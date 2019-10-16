using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    [HideInInspector]
    public GameObject personagem;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetCharacter(string name) {

        personagem = transform.Find(name).gameObject;

        transform.Find("Tucano").gameObject.SetActive(false);
        transform.Find("Capivara").gameObject.SetActive(false);
        transform.Find("Cube").gameObject.SetActive(false);
        transform.Find("Capsule").gameObject.SetActive(false);
        personagem.SetActive(true);
        
    }
}
