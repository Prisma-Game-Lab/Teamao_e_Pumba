using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TucanoAnimator : MonoBehaviour
{
    
	Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    
    void Update()
    {
    	if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
    	{
        	anim.SetBool("running", true);
    	}else {
    		anim.SetBool("running", false);
    	}
    }
}
