﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentAxis : MonoBehaviour
{
    public float movementSpeed = 10.0f;

    void Update()
    {
        float translationV = 0;
        float translationH = 0;
        if(gameObject.name == "Player1") {
            translationV = Input.GetAxis("Vertical") * movementSpeed;
            translationH = Input.GetAxis("Horizontal") * movementSpeed;
        }
        if(gameObject.name == "Player2") {
            translationV = Input.GetAxis("Vertical2") * movementSpeed;
            translationH = Input.GetAxis("Horizontal2") * movementSpeed;
        }
        if(gameObject.name == "Player3") {
            translationV = Input.GetAxis("Vertical3") * movementSpeed;
            translationH = Input.GetAxis("Horizontal3") * movementSpeed;
        }
        if(gameObject.name == "Player4") {
            translationV = Input.GetAxis("Vertical4") * movementSpeed;
            translationH = Input.GetAxis("Horizontal4") * movementSpeed;
        }
        Debug.Log(translationH);
        translationV *= Time.deltaTime;
        translationH *= Time.deltaTime;
        if(translationH == 1) {
            //transform.Rotate(0,90,0);
        }
        transform.position += transform.forward*translationV;
        transform.position += transform.right*translationH;
        //transform.position += transform.forward*translationH;

    
        
    }
}