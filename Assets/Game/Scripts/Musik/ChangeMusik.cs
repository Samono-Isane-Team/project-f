using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusik : MonoBehaviour
{
    public int indexMusik;

    private void Start()
    {
        if (GameObject.Find("Audio Manager") != null)
        {
            MusikController.Instance.ChangeMusik(indexMusik);
        }
    }
}
