using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] time;

    private float isTime;

    private void Awake()
    {
        isTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer();
    }

    private void timer()
    {
        time[0].text = ((int)GameManager.instance.maxGameTime / 60 % 60).ToString();
        time[1].text = ((int)GameManager.instance.maxGameTime % 60).ToString();
    }
}
