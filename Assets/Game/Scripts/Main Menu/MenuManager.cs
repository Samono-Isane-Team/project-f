using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    // * fungsi memulai game baru
    public void NewGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        PlayerPrefs.DeleteAll();
    }

    // * fungsi melanjutkan permainan
    public void ContinueGame(string SceneName)
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
