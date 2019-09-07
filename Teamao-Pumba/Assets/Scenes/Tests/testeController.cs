using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testeController : MonoBehaviour
{
    Vector2 i_movement;
    float speed = 10f;
  

    
    void Update()
    {
        Move();
    }

    private void Move(){
        Vector3 movement = new Vector3(i_movement.x,0,i_movement.y) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnMove(InputValue value ){
        i_movement  = value.Get<Vector2>();
    }

    
}
