using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{

    public Transform personagem;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetCharacter(string name) {

        personagem = transform.Find(name);

        transform.Find("Tucano").gameObject.SetActive(false);
        transform.Find("Cylinder").gameObject.SetActive(false);
        transform.Find("Cube").gameObject.SetActive(false);
        transform.Find("Capsule").gameObject.SetActive(false);
        personagem.gameObject.SetActive(true);
        
    }
}
