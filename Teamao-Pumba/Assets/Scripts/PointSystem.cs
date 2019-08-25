using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private int VirtualPoints;
    private int RealPoints;

    void Start()
    {
        VirtualPoints = 0;
        RealPoints = 0;
    }
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Item") {
            VirtualPoints++;
        }
        if(other.gameObject.tag == "Base") {
            RealPoints += VirtualPoints;
            VirtualPoints = 0;
        }
    }
}
