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
    public Quest quest;

    [Header("System Highscore")]
    public HighScore highScore;

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
                    // * permainan selesai
                    isStop = true;
                    Debug.Log(isStop + " isStop");

                    panelResult.SetActive(true);
                    textResult.text = "Waktu habis";
                    textPoint.text = "Nilai Akhir Anda : " + Quest.totalPoint.ToString();

                    // TODO unlock system
                    if (Quest.pilihSoal == UnlockLevel.currentLevel)
                    {
                        UnlockLevel.currentLevel += 1;
                        PlayerPrefs.SetInt("Level", UnlockLevel.currentLevel);
                    }

                    // TODO system rating 
                    quest.StarRating();

                    // TODO system highscore
                    highScore.UpdateHighscore();
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
