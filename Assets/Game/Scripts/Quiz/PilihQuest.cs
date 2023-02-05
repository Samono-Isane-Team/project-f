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
        LoadHighscore();
    }

    // * memilih quest
    public void ButtonLoadInGame(int nomorQuest)
    {
        Quest.nomorQuest = nomorQuest;
        SceneManager.LoadScene(2);
    }

    // * load highscore
    private void LoadHighscore()
    {
        for (int i = 0; i < scorePlayers.Length; i++)
        {
            scorePlayers[i] = PlayerPrefs.GetFloat("ScorePlayer" + i, 0);
            textScores[i].text = scorePlayers[i].ToString();

            namePlayers[i] = PlayerPrefs.GetString("NamePlayer" + i, "Player" + i);
            textNames[i].text = namePlayers[i];
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
            PlayerPrefs.DeleteKey("ScorePlayer" + i);
            PlayerPrefs.DeleteKey("NamePlayer" + i);
        }

        LoadHighscore();
    }

    // * back to main menu
    public void ButtonBackToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}

