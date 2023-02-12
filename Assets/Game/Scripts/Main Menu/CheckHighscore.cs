using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CheckHighscore : MonoBehaviour
{
    [Header("System Highscore")]
    public GameObject panelHighscore;
    public string[] namePlayers;
    public float[] scorePlayers;
    public TMP_Text[] textNames;
    public TMP_Text[] textScores;


    // * button load highscore
    public void LoadHighscore(int nomorQuest)
    {

        Quest.pilihSoal = nomorQuest;

        for (int i = 0; i < scorePlayers.Length; i++)
        {
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

        for (int i = 0; i < scorePlayers.Length; i++)
        {

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
}
