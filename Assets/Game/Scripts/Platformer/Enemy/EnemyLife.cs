using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    // [Header("Item Reward")]
    // public TMP_Text textItem;

    // * fungsi membunuh musuh
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerReward.item += 2;
            // textItem.text = PlayerReward.item.ToString();
            Destroy(gameObject);
        }
    }
}
