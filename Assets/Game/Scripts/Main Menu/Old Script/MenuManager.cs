using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    // * fungsi melanjutkan permainan
    public void LoadLevelGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    // * fungsi keluar aplikasi
    public void KeluarPermainan()
    {
        Debug.Log("Keluar Aplikasi");
        Application.Quit();
    }
}
