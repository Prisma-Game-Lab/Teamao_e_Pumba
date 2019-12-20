using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowVIDEO : MonoBehaviour
{
	public GameObject target;
	public Vector3 offset; 

	void Start(){
		offset = transform.position - target.transform.position;
	}

    void LateUpdate(){
 		transform.position = target.transform.position + offset;
 	}

 }
