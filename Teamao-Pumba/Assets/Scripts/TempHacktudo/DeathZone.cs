using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public GameObject Players;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player1") {
            Players.transform.GetChild(0).GetChild(0).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(0).GetChild(1).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(0).GetChild(2).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(0).GetChild(3).gameObject.transform.position = new Vector3(0,0,0);
        }
        if(other.gameObject.tag == "Player2") {
            Players.transform.GetChild(1).GetChild(0).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(1).GetChild(1).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(1).GetChild(2).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(1).GetChild(3).gameObject.transform.position = new Vector3(0,0,0);
        }
        if(other.gameObject.tag == "Player3") {
            Players.transform.GetChild(2).GetChild(0).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(2).GetChild(1).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(2).GetChild(2).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(2).GetChild(3).gameObject.transform.position = new Vector3(0,0,0);
        }
        if(other.gameObject.tag == "Player4") {
            Players.transform.GetChild(3).GetChild(0).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(3).GetChild(1).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(3).GetChild(2).gameObject.transform.position = new Vector3(0,0,0);
            Players.transform.GetChild(3).GetChild(3).gameObject.transform.position = new Vector3(0,0,0);
        }
    }
}
