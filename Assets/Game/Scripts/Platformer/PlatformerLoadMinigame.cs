using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlatformerLoadMinigame : MonoBehaviour
{

    [Header("System Enter Minigame")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enterMinigameButton;

    [Header("System Obstacle")]
    [SerializeField] private GameObject wall0, wall1;

    [Header("System life point")]
    [SerializeField] private TMP_Text textTotalLife;


    private void Start()
    {
        GameManager.unloadScene = false;
    }

    private void Update()
    {
        // * menonaktifkan scene minigame jika player surrender.
        if (GameManager.unloadScene == true)
        {
            player.SetActive(true);
            textTotalLife.text = PlayerLife.currentLifePoint.ToString();


            GameManager.unloadScene = false;
        }
    }

    // * destroy wall
    private void DestroyWall()
    {
        if (Quest.pilihSoal == 0)
        {
            Debug.Log("halo wall 0");
            Destroy(wall0);
        }
        else if (Quest.pilihSoal == 1)
        {
            Debug.Log("halo wall 1");
            Destroy(wall1);
        }
    }

    // * jika didalam area minigame maka aktifkan trigger
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            enterMinigameButton.SetActive(true);
        }
    }

    // * jika keluar dari area minigame maka nonaktifkan trigger
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            enterMinigameButton.SetActive(false);
        }
    }

    // * memanggil scene lain ke dalam game
    public void LoadMiniGame(int nomorQuest)
    {
        player.SetActive(false);
        Quest.pilihSoal = nomorQuest;
        SceneManager.LoadScene("QuizGame", LoadSceneMode.Additive);

        // * destroy wall
        DestroyWall();
    }


}
