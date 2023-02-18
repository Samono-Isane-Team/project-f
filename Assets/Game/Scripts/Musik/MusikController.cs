using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusikController : MonoBehaviour
{
    // * melakukan inisiate script musik control
    public static MusikController Instance { get; set; }

    [Header("System Musik")]
    public AudioClip[] clipMusik;
    public AudioSource audioMusik;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMusik(int indexMusik)
    {
        if (audioMusik.clip != clipMusik[indexMusik])
        {
            // * mematikan musik
            audioMusik.Stop();
            // * mengganti musik berdasarkan index musik
            audioMusik.clip = clipMusik[indexMusik];
            // * memutar musik
            audioMusik.Play();
        }
    }
}
