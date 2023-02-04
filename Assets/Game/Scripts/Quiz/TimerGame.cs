using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimerGame : MonoBehaviour
{

    [Header("Timer")]
    public Slider timerSlider;
    public TMP_Text textTimer;
    public static bool isStop; // * false
    [Header("Panel result if lose")]
    public GameObject panelResult;
    public TMP_Text textResult;
    public TMP_Text textPoint;

    [Header("System Powerup")]
    public Button timeStopButton;
    public static bool isTimeStop;

    [Header("System Rating / Star")]
    public int gameRound;
    public GameObject[] stars;

    private void Start()
    {
        isStop = false;

        isTimeStop = false;

        textTimer.text = TimeSpan.FromSeconds(timerSlider.value).ToString("mm':'ss");
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

                    string converterTime = TimeSpan.FromSeconds(timerSlider.value).ToString("mm':'ss");
                    textTimer.text = converterTime;
                }
                else
                {
                    isStop = true;
                    Debug.Log(isStop + " isStop");

                    panelResult.SetActive(true);
                    textResult.text = "Waktu habis";
                    textPoint.text = "Nilai Akhir Anda : " + Quest.totalPoint.ToString();

                    //TODO system star
                    // * 10 soal >= 8 jawaban benar = 3 star / >= 5 jawaban benar = 2 star / >= 3 jawaban benar = 1 star / 0 >= 0 = 0 star
                    if (Quest.countTrueAnswer >= gameRound)
                    {
                        // * 3 star
                        for (int i = 0; i < 3; i++)
                        {
                            stars[i].SetActive(true);
                        }
                    }
                    else if (Quest.countTrueAnswer >= gameRound / 2 && Quest.countTrueAnswer != gameRound)
                    {
                        // * 2 star
                        for (int i = 0; i < 2; i++)
                        {
                            stars[i].SetActive(true);
                        }
                    }
                    else if (Quest.countTrueAnswer >= gameRound / 4 && Quest.countTrueAnswer != gameRound)
                    {
                        // * 1 star
                        for (int i = 0; i < 1; i++)
                        {
                            stars[i].SetActive(true);
                        }
                    }
                    else
                    {
                        // * 0 star
                        // for (int i = 0; i < 0; i++)
                        // {
                        //     stars[i].SetActive(true);
                        // }
                    }
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
