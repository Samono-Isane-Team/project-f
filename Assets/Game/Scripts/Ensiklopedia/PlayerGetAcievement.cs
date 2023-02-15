using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetAcievement : MonoBehaviour
{

    public InGaneAchievement inGaneAchievement;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "item-a")
        {
            inGaneAchievement.UpdateRiwayatAchievement(0);
            Destroy(collider.gameObject);
        }
        else if (collider.name == "item-b")
        {
            inGaneAchievement.UpdateRiwayatAchievement(1);
            Destroy(collider.gameObject);
        }
    }
}
