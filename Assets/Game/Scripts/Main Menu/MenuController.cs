using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{



    // Fungsi memulai permaian baru
    public void PermananBaru(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    // Fungsi keluar aplikasi
    public void KeluarPermainan()
    {
        Debug.Log("Keluar Aplikasi");
        Application.Quit();
    }
}
