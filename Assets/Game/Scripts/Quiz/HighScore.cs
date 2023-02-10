using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    [Header("System Highscore")]
    public string[] namePlayer;
    public float[] scorePlayer;
    private int newIndexNamePlayer;

    // * UI
    public TMP_InputField inputFieldName;
    public Button buttonSave;
    public TMP_Text textNomorRank;
    public TMP_Text[] textNamePlayer;
    public TMP_Text[] textScorePlayer;
    public Button buttonMainMenu;

    private void Start()
    {
        LoadHighscore();

        // ! testing HG berdasarkan soal
        // Debug.Log("INI KONTROL QUEST DARI HS KE-" + Quest.pilihSoal);
        if (Quest.pilihSoal == 0)
        {
            Debug.Log("INI SOAL PERTAMA");
        }
        else if (Quest.pilihSoal == 1)
        {
            Debug.Log("INI SOAL KEDUA");
        }
    }

    // * mengecek isi input field
    public void NamePlayerDetect()
    {

        if (inputFieldName.text.Length > 0)
        {
            buttonSave.interactable = true;
        }
        else
        {
            buttonSave.interactable = true;
        }

    }

    // * load highscore
    private void LoadHighscore()
    {
        for (int i = 0; i < namePlayer.Length; i++)
        {

            // namePlayer[i] = PlayerPrefs.GetString("NamePlayerSatu" + i, "Player" + i);
            // textNamePlayer[i].text = namePlayer[i];

            // scorePlayer[i] = PlayerPrefs.GetFloat("ScorePlayerSatu" + i, 1);
            // textScorePlayer[i].text = scorePlayer[i].ToString();


            if (Quest.pilihSoal == 0)
            {
                namePlayer[i] = PlayerPrefs.GetString("NamePlayerSatu" + i, "Player" + i);
                textNamePlayer[i].text = namePlayer[i];

                scorePlayer[i] = PlayerPrefs.GetFloat("ScorePlayerSatu" + i, 1);
                textScorePlayer[i].text = scorePlayer[i].ToString();
            }
            else if (Quest.pilihSoal == 1)
            {
                namePlayer[i] = PlayerPrefs.GetString("NamePlayerDua" + i, "Player" + i);
                textNamePlayer[i].text = namePlayer[i];

                scorePlayer[i] = PlayerPrefs.GetFloat("ScorePlayerDua" + i, 1);
                textScorePlayer[i].text = scorePlayer[i].ToString();
            }

        }
    }

    // * save highscore
    // * taruh pada script quest
    public void UpdateHighscore()
    {

        int newIndexHighscore = -1;

        for (int i = 0; i < scorePlayer.Length; i++)
        {
            if (Quest.totalPoint >= scorePlayer[i])
            {
                newIndexHighscore = i;

                break;
            }
        }

        if (newIndexHighscore >= 0)
        {
            for (int i = scorePlayer.Length - 1; i > newIndexHighscore; i--)
            {
                namePlayer[i] = namePlayer[i - 1];
                textNamePlayer[i].text = namePlayer[i];

                scorePlayer[i] = scorePlayer[i - 1];
                textScorePlayer[i].text = scorePlayer[i].ToString();
            }

            scorePlayer[newIndexHighscore] = Quest.totalPoint;
            newIndexNamePlayer = newIndexHighscore;

            textNomorRank.text = (newIndexHighscore + 1).ToString();

            // * mengkosongkan posisi highscore
            textNamePlayer[newIndexNamePlayer].text = "";
            textScorePlayer[newIndexHighscore].text = "";
        }
        else
        {
            inputFieldName.interactable = false;
            buttonMainMenu.interactable = true;
        }
    }

    // * menyimpan data highscore
    public void ButtonSave()
    {
        // * input nama pemain
        namePlayer[newIndexNamePlayer] = inputFieldName.text;

        // * update tampilan highscore
        textNamePlayer[newIndexNamePlayer].text = namePlayer[newIndexNamePlayer];
        textScorePlayer[newIndexNamePlayer].text = scorePlayer[newIndexNamePlayer].ToString();

        // for (int i = 0; i < namePlayer.Length; i++)
        // {
        //     PlayerPrefs.SetString("NamePlayer" + i, namePlayer[i]);
        //     PlayerPrefs.SetFloat("ScorePlayer" + i, scorePlayer[i]);
        // }

        // ! testing HG berdasarkan soal
        if (Quest.pilihSoal == 0)
        {
            for (int i = 0; i < namePlayer.Length; i++)
            {
                PlayerPrefs.SetString("NamePlayerSatu" + i, namePlayer[i]);
                PlayerPrefs.SetFloat("ScorePlayerSatu" + i, scorePlayer[i]);
            }
        }
        else if (Quest.pilihSoal == 1)
        {
            for (int i = 0; i < namePlayer.Length; i++)
            {
                PlayerPrefs.SetString("NamePlayerDua" + i, namePlayer[i]);
                PlayerPrefs.SetFloat("ScorePlayerDua" + i, scorePlayer[i]);
            }
        }

        buttonSave.interactable = false;
        inputFieldName.interactable = false;

        buttonMainMenu.interactable = true;
    }

}
