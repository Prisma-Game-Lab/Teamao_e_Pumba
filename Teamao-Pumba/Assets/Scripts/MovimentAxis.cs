using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentAxis : MonoBehaviour
{
    private Animator anim;
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 10.0f;

    void FixedUpdate()
    {
        anim = this.GetComponent<Animator>();
        if (!IsMoving) return;

        float translationV = 0;
        float translationH = 0;
        for (int i = 0; i < 4; i++)
        {
            if (gameObject.tag == "Player" + (i + 1).ToString())
            {
                translationV = Input.GetAxis("Vertical" + (i + 1).ToString()) * movementSpeed;
                translationH = Input.GetAxis("Horizontal" + (i + 1).ToString()) * movementSpeed;


            }
            //if(((translationV > 0.5 || translationV < -0.5) || (translationH > 0.5 || translationH < -0.5)) && gameObject.name == "Tucano") {
                //anim.SetBool("running", true);
            //}
            //else {
                //if(gameObject.name == "Tucano") {
                    //anim.SetBool("running", false);
                //}
            //}
        }
        if(IsMoving && gameObject.name == "Tucano") {
            anim.SetBool("running", true);
        }
        if(!IsMoving && gameObject.name == "Tucano") {
            anim.SetBool("running", false);
        }
        
        Debug.Log("V" +translationV);
        Debug.Log("H" +translationH);
        translationV *= Time.deltaTime;
        translationH *= Time.deltaTime;

        transform.position += Direction() * Time.deltaTime;
        transform.rotation = Rotation;

    }

    private bool IsMoving => Direction() != Vector3.zero;
    private Vector3 Direction()
    {
        for (int i = 0; i < 4; i++)
        {
            if (gameObject.tag == "Player" + (i + 1).ToString())
            {
                float h = Input.GetAxis("Horizontal" + (i + 1).ToString()) * movementSpeed;

                float v = Input.GetAxis("Vertical" + (i + 1).ToString()) * movementSpeed;
                return new Vector3(h, 0, v);

            }
        }
        return Vector3.zero;

    }
    private Quaternion Rotation => Quaternion.LookRotation(RotationDirection);

    private Vector3 RotationDirection => Vector3.RotateTowards(transform.forward, Direction(), rotationSpeed * Time.deltaTime, 0);


}