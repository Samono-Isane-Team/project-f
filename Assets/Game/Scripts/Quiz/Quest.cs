using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Quest : MonoBehaviour
{
    public ControlQuest[] controlQuest; //* mengambil script control quest

    [Header("Menampilkan Soal dan Jawaban")]
    // * menampilkan soal yang mana
    public static int nomorQuest;
    // * menampilkan text soal
    public TMP_Text soalText;
    // * menampilkan text jawaban
    public TMP_Text[] jawabanTexts;
    // * menyimpan nomor soal
    private int nomorSoal;
    // * random soal
    [Tooltip("Disesuaikan dengan jumlah soal")]
    public int[] randomSoals;
    // * random jawaban soal
    [Tooltip("Disesuaikan dengan jumlah pilihan jawaban")]
    public int[] randomJawabans;
    // * menentukan jumlah soal
    [Tooltip("Total soal yang diujikan")]
    public int gameRound;

    [Header("Panel Hasil")]
    public GameObject panelHasil;

    [Header("System Point")]
    public TMP_Text pointText;
    public int point;
    private float totalPoint;

    void Start()
    {
        RandomNomorSoal();
        GenerateQuest();
    }

    // * random nomor soal
    private void RandomNomorSoal()
    {
        for (int i = 0; i < randomSoals.Length; i++)
        {
            int arraySoals = randomSoals[i];
            int randomArray = Random.Range(0, randomSoals.Length);
            randomSoals[i] = randomSoals[randomArray];
            randomSoals[randomArray] = arraySoals;
        }
    }

    // * random nomor jawaban
    private void RandomNomorJawaban()
    {
        for (int i = 0; i < randomJawabans.Length; i++)
        {
            int arrayJawabans = randomJawabans[i];
            int randomArray = Random.Range(0, randomJawabans.Length);
            randomJawabans[i] = randomJawabans[randomArray];
            randomJawabans[randomArray] = arrayJawabans;
        }
    }

    //* menampilkan soal dan jawaban ke text
    private void GenerateQuest()
    {
        RandomNomorJawaban();

        soalText.text = controlQuest[nomorQuest].soals[randomSoals[nomorSoal]].elementSoal.soal;

        for (int i = 0; i < jawabanTexts.Length; i++)
        {
            jawabanTexts[i].text = controlQuest[nomorQuest].soals[randomSoals[nomorSoal]].elementSoal.jawabans[randomJawabans[i]];
        }
    }

    //* mencari jawaban benar dari array
    public void ButtonJawabanSoal()
    {
        TMP_Text currentJawaban = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TMP_Text>();

        if (currentJawaban.text == controlQuest[nomorQuest].soals[randomSoals[nomorSoal]].elementSoal.jawabans[controlQuest[nomorQuest].soals[randomSoals[nomorSoal]].elementSoal.jawabanBenar])
        {
            Debug.Log("Benar");

            totalPoint += point;
        }
        else
        {
            Debug.Log("Salah");

            if (totalPoint >= 0)
            {
                totalPoint -= (point / 2);
            }
        }

        nomorSoal++;
        Debug.Log(nomorSoal);

        // * menghitung jumlah round game
        if (nomorSoal == gameRound)
        {
            panelHasil.transform.GetChild(0).GetComponent<TMP_Text>().text = "Selamat semua soal telah dijawab";
            panelHasil.transform.GetChild(1).gameObject.SetActive(false);
            panelHasil.SetActive(true);

            pointText.text = "Nilai Akhir Anda : " + totalPoint.ToString();
        }
        else
        {
            GenerateQuest();
        }

    }

    //* next soal
    public void ButtonNextSoal()
    {
        panelHasil.SetActive(false);

        nomorSoal++;

        GenerateQuest();
    }
}
