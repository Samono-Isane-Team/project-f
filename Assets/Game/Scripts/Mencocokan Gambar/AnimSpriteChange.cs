using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimSpriteChange : MonoBehaviour
{
    [Header("System Animation Change Sprite")]
    public Sprite spriteDepan;
    public Sprite spriteBelakang;
    public Image imageCard;


    public void ChangeSpriteCard()
    {
        if (imageCard.sprite == spriteBelakang)
        {
            imageCard.sprite = spriteDepan;
        }
        else
        {
            imageCard.sprite = spriteBelakang;
        }
    }

}
