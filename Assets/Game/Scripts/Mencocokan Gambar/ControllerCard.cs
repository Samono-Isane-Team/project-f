using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControllerCard : MonoBehaviour
{

    [Header("System Random Card & Sprite")]
    // * menghitung jumlah kartu
    [Tooltip("Sesuaikan dengan jumlah kartu")]
    public int countCard;
    // * card array
    [Tooltip("Di sesuaikan dengan jumlah card")]
    public int[] cardIndexRandoms;
    [Tooltip("Menyimpan array gambar kartu yang akan dirandom, minimal 6 gambar")]
    public Sprite[] spriteCardDepans;
    public int[] indexRandomSprites;
    public GameObject parrentCard;
    [Tooltip("Image dari button kartu")]
    public Button[] imageCards;
    private int indexSprite;

    [Header("System Match")]
    [Tooltip("Tidak perlu diisi")]
    public Sprite spriteRecentCard;
    public AnimationClip clipCardFlip;
    [Tooltip("Tidak perlu diisi")]
    public GameObject currentButtonCard, recentButtonCard;

    [Header("System Win/lose")]
    public GameObject panelEndGame;
    public TMP_Text textEndGame;

    [Header("System health")]
    public GameObject[] healths;
    // * jika ingin menggantinya dengan spirte lain
    // public Sprite spriteLoseHealth;
    public int lifeChance;

    [Header("System Audio Effect")]
    public SfxMencocokanGambar sfxMencocokanGambar;

    private void Start()
    {

        // TODO system health
        lifeChance = healths.Length;

        // TODO level system
        LevelSystem();

        // * membuat array card dengan random
        RandomArrayCard();
        IndexRandom(cardIndexRandoms);

        // * menghitung card child
        CountCardChild();


        // * index random card
        RandomCard();
        IndexRandom(indexRandomSprites);

        ChangeSpriteCards();

    }

    // TODO level system
    private void LevelSystem()
    {
        countCard = SelectLevelCocokGambar.indexCardCount;
        for (int i = 0; i < countCard; i++)
        {
            parrentCard.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // * membuat array card dengan random
    private void RandomArrayCard()
    {
        cardIndexRandoms = new int[countCard];

        for (int i = 0; i < countCard; i++)
        {
            cardIndexRandoms[i] = i;
        }
    }

    // * menghitung card child
    private void CountCardChild()
    {
        imageCards = new Button[countCard]; // * value array
        for (int i = 0; i < countCard; i++)
        {
            // * mengambil komponen
            imageCards[i] = parrentCard.transform.GetChild(i).GetComponent<Button>();
        }
    }

    // * index random card
    private void RandomCard()
    {
        indexRandomSprites = new int[spriteCardDepans.Length];

        for (int i = 0; i < spriteCardDepans.Length; i++)
        {
            indexRandomSprites[i] = i;
        }
    }

    // * mengecek game sudah berakhir atau belum
    private bool isGameDone()
    {
        for (int i = 0; i < countCard; i++)
        {
            if (parrentCard.transform.GetChild(i).gameObject.activeInHierarchy == true)
            {
                return false;
            }
        }

        return true;
    }

    // * mengganti sprite card
    private void ChangeSpriteCards()
    {

        for (int i = 0; i < countCard; i++)
        {
            if (i % 2 == 0 && i != 0)
            {
                indexSprite += 1;
            }
            imageCards[cardIndexRandoms[i]].GetComponent<AnimSpriteChange>().spriteDepan = spriteCardDepans[indexRandomSprites[indexSprite]];
        }
    }

    // * untuk melakukan random array
    private void IndexRandom(int[] intValue)
    {
        for (int i = 0; i < intValue.Length; i++)
        {
            int a = intValue[i];
            int b = Random.Range(0, intValue.Length);
            intValue[i] = intValue[b];
            intValue[b] = a;
        }
    }

    // * untuk melakukan flip atau membalikkan kartu
    public void ButtonCard(Animator animObject)
    {
        if (animObject.GetBool("isFlip") == false)
        {
            animObject.SetBool("isFlip", true);
            // Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            sfxMencocokanGambar.AudioMencocokanGambarFlipCard();

            currentButtonCard = EventSystem.current.currentSelectedGameObject.gameObject;

            // * mematikan fungsi dari button
            currentButtonCard.GetComponent<Button>().enabled = false;

            if (spriteRecentCard == null) // * flip card pertama
            {
                spriteRecentCard = currentButtonCard.GetComponent<AnimSpriteChange>().spriteDepan;

                recentButtonCard = currentButtonCard;
            }
            else // * flip card kedua
            {
                if (currentButtonCard.GetComponent<AnimSpriteChange>().spriteDepan.name == spriteRecentCard.name)
                {
                    // buttonCurrentSelected.gameObject.SetActive(false);
                    Invoke("MatchCard", clipCardFlip.length + 0.2f); // * jika kartu sama
                    // sfxMencocokanGambar.AudioMencocokanGambarClipTrue();
                }
                else
                {
                    Invoke("NotMatchCard", clipCardFlip.length + 0.2f); // * jika kartu tidak sama

                }

                // * limit hanya 2 kartu yang bisa di select
                for (int i = 0; i < SelectLevelCocokGambar.indexCardCount; i++)
                {
                    imageCards[i].enabled = false;

                }

            }

        }
        else
        {
            animObject.SetBool("isFlip", false);
            // sfxMencocokanGambar.AudioMencocokanGambarFlipCard();
        }
    }

    // * berfungsi mencocokan kartu
    private void MatchCard()
    {
        currentButtonCard.SetActive(false);
        recentButtonCard.SetActive(false);
        sfxMencocokanGambar.AudioMencocokanGambarClipTrue();

        spriteRecentCard = null;

        // * reset semua fungsi button card
        for (int i = 0; i < SelectLevelCocokGambar.indexCardCount; i++)
        {
            imageCards[i].enabled = true;
        }

        // * kondisi menang game
        Invoke("WinGame", 0.5f);
    }

    // * jika menang permaiann
    private void WinGame()
    {
        if (isGameDone() == true)
        {
            panelEndGame.SetActive(true);

            sfxMencocokanGambar.AudioMencocokanGambarWinGame();
        }
    }

    // * berfungsi jika kartu tidak cocok
    private void NotMatchCard()
    {
        ButtonCard(recentButtonCard.GetComponent<Animator>());
        ButtonCard(currentButtonCard.GetComponent<Animator>());
        sfxMencocokanGambar.AudioMencocokanGambarFlipCard();

        recentButtonCard.GetComponent<Button>().enabled = true;
        currentButtonCard.GetComponent<Button>().enabled = true;

        spriteRecentCard = null;

        // * reset semua fungsi button card
        for (int i = 0; i < SelectLevelCocokGambar.indexCardCount; i++)
        {
            imageCards[i].enabled = true;
        }

        // TODO system health
        if (lifeChance > 0)
        {

            // healths[healths.Length - lifeChance].GetComponent<Image>().sprite = spriteLoseHealth; // * jika ingin menggantinya dengan spirte lain
            healths[healths.Length - lifeChance].SetActive(false);

            lifeChance -= 1;
        }
        else // * jika kalah game health habis
        {
            Invoke("LoseGame", 0.5f);
        }
    }

    // * jika kalah permainan
    private void LoseGame()
    {
        Debug.Log("Lose");
        panelEndGame.SetActive(true);
        textEndGame.text = "Anda Kalah";

        sfxMencocokanGambar.AudioMencocokanGambarLoseGame();
    }

    // * restar game
    public void ButtonRestarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
