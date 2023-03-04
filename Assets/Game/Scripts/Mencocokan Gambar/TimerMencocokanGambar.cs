using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;


public class TimerMencocokanGambar : MonoBehaviour
{
    [Header("System Timer")]
    public TMP_Text textTimer;
    public float totalTimer;
    public bool isTimerStart;

    [Header("System Win/lose")]
    public GameObject panelEndGame;
    public TMP_Text textEndGame;

    private void Start()
    {
        TimerStart();
    }

    // * menjalankan timer
    private void TimerStart()
    {
        totalTimer = SelectLevelCocokGambar.timerSetUp;

        isTimerStart = true;

        StartCoroutine(Timer());
    }


    // * menghitung waktu mundur
    IEnumerator Timer()
    {
        while (isTimerStart == true)
        {
            totalTimer -= Time.deltaTime;

            textTimer.text = TimeSpan.FromSeconds(totalTimer).ToString("mm':'ss");

            if (totalTimer <= 0)
            {
                isTimerStart = false;

                Debug.Log("Kalah waktu habis!");
                panelEndGame.SetActive(true);
                textEndGame.text = "Anda Kalah";
            }

            yield return null;
        }
    }

}
