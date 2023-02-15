using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGaneAchievement : MonoBehaviour
{
    [Header("System Achievement")]
    public int[] riwayatAchievement;

    private void Start()
    {
        LoadRiwayatAchievement();
    }

    public void UpdateRiwayatAchievement(int index)
    {
        if (riwayatAchievement[index] == 0)
        {
            // * mengubah value pada riwayat menjadi 1
            riwayatAchievement[index] += 1;
            // * simpan riwayat
            PlayerPrefs.SetInt("Achievement" + index, riwayatAchievement[index]);
        }
    }

    public void LoadRiwayatAchievement()
    {
        for (int i = 0; i < riwayatAchievement.Length; i++)
        {
            // * load riwayat Achievement
            riwayatAchievement[i] = PlayerPrefs.GetInt("Achievement" + i, 0);
        }
    }

}
