using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // * berfungsi untuk berganti scene saja
    public void LoadOtherScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    // * Unload minigame platformer
    public static bool unloadScene;
    public void UnLoadMiniGame(string nameScene)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(nameScene));
        unloadScene = true;
    }

    // * berfungsi keluar aplikasi
    public void KeluarPermainan()
    {
        Debug.Log("Keluar Aplikasi");
        Application.Quit();
    }

    // * reset game
    public static void DeleteAllSaveData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All save data deleted.");
    }
}
