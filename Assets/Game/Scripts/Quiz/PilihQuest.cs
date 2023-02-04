using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PilihQuest : MonoBehaviour
{

    // * memilih quest
    public void ButtonLoadInGame(int nomorQuest)
    {
        Quest.nomorQuest = nomorQuest;
        SceneManager.LoadScene(1);
    }
}
