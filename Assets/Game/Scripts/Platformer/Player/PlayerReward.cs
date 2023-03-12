using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerReward : MonoBehaviour
{

    [Header("Item Reward")]
    public static int item = 0;
    public TMP_Text textItem;

    [Header("System life point")]
    public int minimalItemToLife;
    public static int currenItemToLife;

    private void Start()
    {
        currenItemToLife = minimalItemToLife;
        item = 0;
        textItem.text = item.ToString();
    }

    private void Update()
    {
        textItem.text = item.ToString();
    }

    // * fungsi deteksi mengambil coin
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Item"))
        {
            item++;
            Destroy(collider.gameObject);
        }
    }

}
