using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxMencocokanGambar : MonoBehaviour
{
    public AudioSource audioEffect;
    public AudioClip clipWinGame;
    public AudioClip clipTrue;
    public AudioClip clipFlipCard;
    public AudioClip loseGame;

    // * sfx menang
    public void AudioMencocokanGambarWinGame()
    {
        audioEffect.PlayOneShot(clipWinGame);
    }

    // * sfx kalah
    public void AudioMencocokanGambarLoseGame()
    {
        audioEffect.PlayOneShot(loseGame);
    }

    // * sfx kartu cocok
    public void AudioMencocokanGambarClipTrue()
    {
        audioEffect.PlayOneShot(clipTrue);
    }

    // * sfx kartu tidak cocok
    public void AudioMencocokanGambarFlipCard()
    {
        audioEffect.PlayOneShot(clipFlipCard);
    }
}
