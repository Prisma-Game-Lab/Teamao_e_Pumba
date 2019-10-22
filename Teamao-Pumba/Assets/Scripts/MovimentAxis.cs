using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentAxis : MonoBehaviour
{
    private Animator anim;
    public float movementSpeed;
    public float rotationSpeed;

    private bool stunned = false;

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
            if (((translationV > 1 || translationV < -1) || (translationH > 1 || translationH < -1)) && (gameObject.name == "Tucano" || gameObject.name == "Capivara"))
            {
                anim.SetBool("running", true);
            }
            else
            {
                if (gameObject.name == "Tucano" || gameObject.name == "Capivara")
                {
                    anim.SetBool("running", false);
                }
            }
        }
        translationV *= Time.deltaTime;
        translationH *= Time.deltaTime;

        if (!stunned)
            transform.position += Direction() * Time.deltaTime;
        transform.rotation = Rotation;


    }
    private void Update()
    {
        if (IsMoving == false)
        {
            Debug.Log("PARADO!!");
            anim.SetBool("running", false);
        }
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

    public void stunSelf(float stunDuration)
    {
        if (!stunned)
        {
            StartCoroutine(stunRoutine(stunDuration));
        }

    }
    IEnumerator stunRoutine(float stunDuration)
    {
        this.stunned = true;

        yield return new WaitForSeconds(stunDuration);

        this.stunned = false;
    }


}