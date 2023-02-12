using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlatformerLoadMinigame : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enterMinigameButton;

    private void Update()
    {
        // * menonaktifkan scene minigame jika player surrender.
        if (GameManager.unloadScene == true)
        {
            player.SetActive(true);
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
        Quest.pilihSoal = nomorQuest;
        SceneManager.LoadScene("QuizGame", LoadSceneMode.Additive);
    }


}
