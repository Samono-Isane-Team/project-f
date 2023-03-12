using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    [Header("System life point")]
    private Rigidbody2D rb;
    public GameObject player;
    [SerializeField] private TMP_Text textTotalLife;
    [SerializeField] private int totalLifePoint;
    public static int currentLifePoint;
    [SerializeField] private GameObject gameoverPanel;
    private Animator anim;

    [Header("System save point")]
    private Vector2 respownPoint;

    private void Start()
    {

        currentLifePoint = totalLifePoint;

        textTotalLife.text = currentLifePoint.ToString();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        respownPoint = transform.position;
    }

    private void Update()
    {

        // * update life point ketika item sudah memenuhi syarat
        if (PlayerReward.item >= PlayerReward.currenItemToLife)
        {
            PlayerReward.item -= PlayerReward.currenItemToLife;
            currentLifePoint += 1;
        }
        // * update text life point ketika terjadi perubahan
        textTotalLife.text = currentLifePoint.ToString();

        // * player mati
        if (currentLifePoint == 0)
        {
            Debug.Log("Player die");
            Destroy(player);
            gameoverPanel.SetActive(true);
        }
    }


    // * player mati jika tertabrak musuh
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
            {
                if (currentLifePoint > 0)
                {
                    Die();
                }
                // else
                // {
                //     Debug.Log("Game Overpanel");
                //     Destroy(player);
                //     gameoverPanel.SetActive(true);
                // }
            }
        }
    }

    // * fungsi player mati
    private void Die()
    {
        Debug.Log("Kembali ke respawn");
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("die");
        rb.bodyType = RigidbodyType2D.Static;
        currentLifePoint -= 1;
        textTotalLife.text = currentLifePoint.ToString();
    }

    // * kembalikan ke check point jika player mati
    private void CheckPoint()
    {
        anim.SetInteger("state", 0);
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = respownPoint;
    }


    // * save point
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("SavePoint"))
        {
            respownPoint = transform.position;
        }
    }



}
