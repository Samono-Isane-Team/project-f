using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PilihQuest : MonoBehaviour
{

    [Header("System Highscore")]
    public GameObject panelHighscore;
    public string[] namePlayers;
    public float[] scorePlayers;
    public TMP_Text[] textNames;
    public TMP_Text[] textScores;

    private void Start()
    {
        // LoadHighscore();
    }


    // ! cek soal doang gk guna
    public void CekSoal(int cekSoal)
    {
        Debug.Log(Quest.pilihSoal);

        Quest.pilihSoal = cekSoal;

        Debug.Log(Quest.pilihSoal);

        if (Quest.pilihSoal == 0)
        {
            Debug.Log("INI SOAL PERTAMA" + Quest.pilihSoal);
        }
        else if (Quest.pilihSoal == 1)
        {
            Debug.Log("INI SOAL KEDUA" + Quest.pilihSoal);
        }
        else
        {
            Debug.Log("TIDAK KEDUANYA" + Quest.pilihSoal);
        }
    }

    // * memilih quest
    public void ButtonLoadInGame(int nomorQuest)
    {
        Quest.pilihSoal = nomorQuest;
        SceneManager.LoadScene("QuizGame");
    }

    // * button load highscore
    public void LoadHighscore(int nomorQuest)
    {

        Quest.pilihSoal = nomorQuest;

        for (int i = 0; i < scorePlayers.Length; i++)
        {
            // scorePlayers[i] = PlayerPrefs.GetFloat("ScorePlayer" + i, 0);
            // textScores[i].text = scorePlayers[i].ToString();

            // namePlayers[i] = PlayerPrefs.GetString("NamePlayer" + i, "Player" + i);
            // textNames[i].text = namePlayers[i];

            if (Quest.pilihSoal == 0)
            {
                scorePlayers[i] = PlayerPrefs.GetFloat("ScorePlayerSatu" + i, 0);
                textScores[i].text = scorePlayers[i].ToString();

                namePlayers[i] = PlayerPrefs.GetString("NamePlayerSatu" + i, "Player" + i);
                textNames[i].text = namePlayers[i];
            }
            else if (Quest.pilihSoal == 1)
            {
                scorePlayers[i] = PlayerPrefs.GetFloat("ScorePlayerDua" + i, 0);
                textScores[i].text = scorePlayers[i].ToString();

                namePlayers[i] = PlayerPrefs.GetString("NamePlayerDua" + i, "Player" + i);
                textNames[i].text = namePlayers[i];
            }
        }
    }

    // * button highscore
    public void ButtonHighscore()
    {
        if (panelHighscore.activeInHierarchy == false)
        {
            panelHighscore.SetActive(true);
        }
        else
        {
            panelHighscore.SetActive(false);
        }
    }

    // * button reset highscore
    public void ButtonResetHighscore()
    {

        // Quest.pilihSoal = nomorQuest;

        for (int i = 0; i < scorePlayers.Length; i++)
        {
            // PlayerPrefs.DeleteKey("ScorePlayer" + i);
            // PlayerPrefs.DeleteKey("NamePlayer" + i);

            if (Quest.pilihSoal == 0)
            {
                PlayerPrefs.DeleteKey("ScorePlayerSatu" + i);
                PlayerPrefs.DeleteKey("NamePlayerSatu" + i);
                LoadHighscore(0);
            }
            else if (Quest.pilihSoal == 1)
            {
                PlayerPrefs.DeleteKey("ScorePlayerDua" + i);
                PlayerPrefs.DeleteKey("NamePlayerDua" + i);
                LoadHighscore(1);
            }
        }

    }

    // * back to main menu
    public void ButtonBackToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}

