using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelCocokGambar : MonoBehaviour
{

    public static int indexCardCount;

    // * memilih level kesulitan dari game cocok gambar
    public void ButtonLevel(int level)
    {
        // * 0 = easy, 1 = normal, 2 = hard

        switch (level)
        {
            case 0:
                indexCardCount = 4;
                break;
            case 1:
                indexCardCount = 8;
                break;
            case 2:
                indexCardCount = 12;
                break;
            default:
                break;
        }

        SceneManager.LoadScene("Mencocokan Gambar");
    }

}
