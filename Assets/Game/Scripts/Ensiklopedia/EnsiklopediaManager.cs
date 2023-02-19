using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnsiklopediaManager : MonoBehaviour
{

    public GameObject panelDetailAchivement;

    [Header("System Achievement")]
    public Button[] buttonAchievement;
    [Tooltip("nama diambil dari nama sprite")]
    public Sprite[] spriteAchievement; // * nama diambil dari nama sprite
    public Image imageDetailAchievement;
    public TMP_Text textNamaDetailAchievement;
    public TMP_Text textLahirDetailAchievement;
    public TMP_Text textMeninggalDetailAchievement;
    public TMP_Text textKeteranganDetailAchievement;

    public string[] stringLahirDetailAchievement;
    public string[] stringMeninggalDetailAchievement;
    [TextArea(5, 5)]
    public string[] stringKeteranganAchievement;
    public int[] riwayatAchievement;

    private void Start()
    {
        LoadAchievement();
    }

    //  * Load Achievement
    private void LoadAchievement()
    {
        // * membuat slot array
        riwayatAchievement = new int[buttonAchievement.Length];
        // * fill dengan angka
        // for (int i = 0; i < buttonAchievement.Length; i++)
        // {
        //     riwayatAchievement[i] = i;
        // }

        for (int i = 0; i < buttonAchievement.Length; i++)
        {
            // * load dan fill dari array riwayat
            riwayatAchievement[i] = PlayerPrefs.GetInt("Achievement" + i, 0);

            // * jika 1 maka sudah terbuka jika 0 belum
            if (riwayatAchievement[i] == 1)
            {
                // buttonAchievement[i].interactable = true;
                buttonAchievement[i].enabled = true;
                buttonAchievement[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    // * update detail Achievement
    public void UpdateDetailAchievement(int indexAchievement)
    {
        // * update sprite dari image
        imageDetailAchievement.sprite = spriteAchievement[indexAchievement];
        // * update nama dari nama sprite
        textNamaDetailAchievement.text = spriteAchievement[indexAchievement].name;
        textLahirDetailAchievement.text = stringLahirDetailAchievement[indexAchievement];
        textMeninggalDetailAchievement.text = stringMeninggalDetailAchievement[indexAchievement];
        // * update keterangan Achievement
        textKeteranganDetailAchievement.text = stringKeteranganAchievement[indexAchievement];
    }


    // * membuka panel detail achievement
    public void ButtonDetailAchievement()
    {
        if (panelDetailAchivement.activeInHierarchy == false)
        {
            panelDetailAchivement.SetActive(true);
        }
        else
        {
            panelDetailAchivement.SetActive(false);
        }
    }

}
