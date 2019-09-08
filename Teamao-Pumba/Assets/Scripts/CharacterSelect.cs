using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetCharacter(string name) {
        transform.Find("Tucano").gameObject.SetActive(false);
        transform.Find("Cylinder").gameObject.SetActive(false);
        transform.Find("Cube").gameObject.SetActive(false);
        transform.Find("Capsule").gameObject.SetActive(false);
        transform.Find(name).gameObject.SetActive(true);
    }
}
