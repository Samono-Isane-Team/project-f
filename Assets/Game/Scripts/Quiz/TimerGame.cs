using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimerGame : MonoBehaviour
{

    public Slider timerSlider;
    public static bool isStop; // * false
    [Header("Panel result if lose")]
    public GameObject panelResult;
    public TMP_Text textResult;
    public TMP_Text textPoint;

    [Header("System Powerup")]
    public Button timeStopButton;
    public static bool isTimeStop;

    private void Start()
    {
        isStop = false;

        isTimeStop = false;
    }

    private void Update()
    {
        Timer();
    }

    // * mengatur waktu game
    private void Timer()
    {
        if (isTimeStop == false)
        {
            if (isStop == false)
            {
                if (timerSlider.value > timerSlider.minValue) //* 120 > 0
                {
                    timerSlider.value -= Time.deltaTime;
                }
                else
                {
                    isStop = true;
                    Debug.Log(isStop + " isStop");

                    panelResult.SetActive(true);
                    textResult.text = "Waktu habis";
                    textPoint.text = "Nilai Akhir Anda : " + Quest.totalPoint.ToString();
                }
            }
        }
        else //true
        {
            Debug.Log("Time Stop Aktif");
        }


    }

    // * powerup timestop
    public void ButtonPowerUpTimeStop()
    {
        isTimeStop = true;

        timeStopButton.interactable = false;
    }

}
