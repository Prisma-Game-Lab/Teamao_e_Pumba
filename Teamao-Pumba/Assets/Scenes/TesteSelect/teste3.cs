using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teste3 : MonoBehaviour
{
    [SerializeField] public List<int> timeList = new List<int>();

    public Text timeText;
    private int selectedTime;


    private void Awake()
    {
        timeList.Add(60);
        timeList.Add(90);
        timeList.Add(120);
    }

    private void Start()
    {
        timeText.text = timeList[0].ToString();
    }

    public void LeftArrow()
    {
        selectedTime--;
        if (selectedTime < 0)
        {
            selectedTime = timeList.Count - 1;
        }
        timeText.text = timeList[selectedTime].ToString();
    }

    public void RightArrow()
    {
        selectedTime++;
        if (selectedTime == timeList.Count)
        {
            selectedTime = 0;
        }
        timeText.text = timeList[selectedTime].ToString();
    }
}
