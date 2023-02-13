using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public ControlQuest[] controlQuest; //* mengambil script control quest

    [Header("Menampilkan Soal dan Jawaban")]
    // * menampilkan soal yang mana
    public static int pilihSoal;
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
    public static float totalPoint;

    [Header("System Timer")]
    public int increaseTime;
    public int decreaseTime;
    public Slider timerSlider;

    [Header("System PowerUp")]
    public Button[] powerUps;
    private int nomorJawabanBenar;

    [Header("System Rating / Star")]
    public GameObject[] stars;
    public int countTrueAnswer;

    [Header("System Highscore")]
    public HighScore highScore;

    private void Start()
    {
        Debug.Log(TimerGame.isStop + " isStop");

        // ! testing HG berdasarkan soal
        Debug.Log(pilihSoal);

        totalPoint = 0;

        RandomNomorSoal();

        GenerateQuest();

    }

    // * powerup help jawaban benar
    public void ButtonPowerUpTrueAnswer() // * powerup 1
    {
        // * mematikan fungsi powerup
        powerUps[1].interactable = false;

        for (int i = 0; i < jawabanTexts.Length; i++)
        {
            if (jawabanTexts[i].text == controlQuest[pilihSoal].soals[randomSoals[nomorSoal]].elementSoal.jawabans[controlQuest[pilihSoal].soals[randomSoals[nomorSoal]].elementSoal.jawabanBenar])
            {
                Debug.Log(i + "Nomor Benar");

                nomorJawabanBenar = i;

                break;
            }
        }

        // * menonaktifkan gameobject
        for (int i = 0; i < jawabanTexts.Length; i++)
        {
            if (i != nomorJawabanBenar)
            {
                jawabanTexts[i].transform.parent.gameObject.SetActive(false);
            }
        }

    }

    // * powerup help 50:50
    public void ButtonPowerUpFifty() // * powerup 0
    {

        // * mematikan fungsi powerup
        powerUps[0].interactable = false;

        for (int i = 0; i < jawabanTexts.Length; i++)
        {
            if (jawabanTexts[i].text == controlQuest[pilihSoal].soals[randomSoals[nomorSoal]].elementSoal.jawabans[controlQuest[pilihSoal].soals[randomSoals[nomorSoal]].elementSoal.jawabanBenar])
            {
                Debug.Log(i + "Nomor Benar");

                nomorJawabanBenar = i;

                break;
            }
        }

        Debug.Log("Break");

        // * menonaktifkan game object
        // * a - 1 && a + 1
        if (nomorJawabanBenar - 1 <= 0)
        {
            jawabanTexts[jawabanTexts.Length - 1].transform.parent.gameObject.SetActive(false);
        }
        else
        {
            jawabanTexts[nomorJawabanBenar - 1].transform.parent.gameObject.SetActive(false);
        }

        if (nomorJawabanBenar + 1 >= jawabanTexts.Length)
        {
            jawabanTexts[0].transform.parent.gameObject.SetActive(false);
        }
        else
        {
            jawabanTexts[nomorJawabanBenar + 1].transform.parent.gameObject.SetActive(false);
        }
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

        // * melakukan random generate quest
        soalText.text = controlQuest[pilihSoal].soals[randomSoals[nomorSoal]].elementSoal.soal;

        for (int i = 0; i < jawabanTexts.Length; i++)
        {

            // * mengaktifkan kembali gameobject setelah powerup
            jawabanTexts[i].transform.parent.gameObject.SetActive(true);

            // * melakukan random generate jawaban 
            jawabanTexts[i].text = controlQuest[pilihSoal].soals[randomSoals[nomorSoal]].elementSoal.jawabans[randomJawabans[i]];
        }
    }

    //* mencari jawaban benar dari array
    public void ButtonJawabanSoal()
    {
        TMP_Text currentJawaban = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TMP_Text>();

        if (currentJawaban.text == controlQuest[pilihSoal].soals[randomSoals[nomorSoal]].elementSoal.jawabans[controlQuest[pilihSoal].soals[randomSoals[nomorSoal]].elementSoal.jawabanBenar])
        {
            totalPoint += point;

            timerSlider.value += increaseTime;

            countTrueAnswer++;
        }
        else
        {
            // * jika point lebih dari atau sama dengan 0 maka jika menjawab salah point dikurangi
            if (totalPoint > 0)
            {
                totalPoint -= (point / 2);
            }
            else if (totalPoint == 0)
            {
                totalPoint = 0;
            }

            timerSlider.value -= decreaseTime;
        }

        nomorSoal++;
        // Debug.Log(nomorSoal);

        // * menghitung jumlah round game
        // * permainan selesai
        if (nomorSoal == gameRound)
        {
            // * menghentikan waktu jika game sudah berakhir
            TimerGame.isStop = true;

            panelHasil.transform.GetChild(0).GetComponent<TMP_Text>().text = "Selamat semua soal telah dijawab";
            // panelHasil.transform.GetChild(1).gameObject.SetActive(false); //* untuk button next tapi udh gk kepakek
            panelHasil.SetActive(true);

            pointText.text = "Nilai Akhir Anda : " + totalPoint.ToString();

            // TODO unlock system
            if (pilihSoal == UnlockLevel.currentLevel)
            {
                UnlockLevel.currentLevel += 1;
                PlayerPrefs.SetInt("Level", UnlockLevel.currentLevel);
            }

            // TODO start system
            StarRating();

            // TODO highscore
            highScore.UpdateHighscore();

        }
        else
        {
            GenerateQuest();
        }

        // * mengaktifkan kembali waktu setelah powerup time stop
        if (TimerGame.isTimeStop == true)
        {
            TimerGame.isTimeStop = false;
        }
    }

    // * star rating
    public void StarRating()
    {
        if (countTrueAnswer >= gameRound)
        {
            //3 star
            for (int i = 0; i < 3; i++)
            {
                stars[i].SetActive(true);
            }
        }
        else if (countTrueAnswer >= gameRound / 2 && countTrueAnswer != gameRound)
        {
            //2 star
            for (int i = 0; i < 2; i++)
            {
                stars[i].SetActive(true);
            }
        }
        else if (countTrueAnswer < gameRound / 2 && countTrueAnswer != 0)
        {
            //1 star
            for (int i = 0; i < 1; i++)
            {
                stars[i].SetActive(true);
            }
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
