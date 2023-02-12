using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{

    [Header("Unlock Level")]
    public GameObject[] levels;
    public static int currentLevel;

    private void Start()
    {
        CheckLevels();
    }

    private void CheckLevels()
    {
        currentLevel = PlayerPrefs.GetInt("Level", 0);

        for (int i = 0; i < currentLevel + 1; i++)
        {
            // * unlock level, child 0 = image
            levels[i].transform.GetChild(0).gameObject.SetActive(false); // * mematikan img lock
            levels[i].GetComponent<Button>().enabled = true; // * mengaktifkan fungsi button

        }
    }

}
