using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public GameObject[] lifeSprite;
    private int totalLifePoint;

    public GameObject gameoverPanel;

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Player"))
        {

            totalLifePoint += 1;

            // * menampilkan jumlah sprite nyawa
            for (int i = 0; i < totalLifePoint; i++)
            {

                if (totalLifePoint < lifeSprite.Length)
                {
                    lifeSprite[i].SetActive(false);
                }
                else
                {
                    Debug.Log("Game Over");
                    gameoverPanel.SetActive(true);
                }

            }

        }

    }

}
