using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] public List<GameObject> timeList = new List<GameObject>();

    private int selectedTime;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LeftArrow();
        }
    }

    public void LeftArrow()
    {
        selectedTime--;
        if (selectedTime < 0)
        {
            selectedTime = timeList.Count - 1;
        }


    }

    public void RightArrow()
    {
        selectedTime++;
        if (selectedTime == timeList.Count)
        {
            selectedTime = 0;
        }

    }
}
