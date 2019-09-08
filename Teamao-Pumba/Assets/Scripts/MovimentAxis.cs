using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentAxis : MonoBehaviour
{
    public float movementSpeed = 10.0f;

    void Update()
    {
        float translationV = 0;
        float translationH = 0;
        for(int i=0;i<4;i++) {
            if(gameObject.name == "Player" + (i+1).ToString()) {
                translationV = Input.GetAxis("Vertical" + (i+1).ToString()) * movementSpeed;
                translationH = Input.GetAxis("Horizontal" + (i+1).ToString()) * movementSpeed;
            }
        }
        translationV *= Time.deltaTime;
        translationH *= Time.deltaTime;
        transform.position += transform.forward*translationV;
        transform.position += transform.right*translationH;
    }
}