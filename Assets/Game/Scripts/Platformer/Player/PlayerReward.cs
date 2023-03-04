using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerReward : MonoBehaviour
{

    [Header("Item Reward")]
    public static int item = 0;
    public TMP_Text textItem;

    private void Start()
    {
        item = 0;
        textItem.text = item.ToString();
    }

    // * fungsi deteksi mengambil coin
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Item"))
        {
            item++;
            Destroy(collider.gameObject);
            textItem.text = item.ToString();
        }

    }

}
