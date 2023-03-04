using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float enemySpeed; //enemy speed
    [SerializeField] float radius; //value checking ground

    [HideInInspector]
    private bool enemyPatrol; //status enemy patrol
    private bool enemyTurn; //status enemy turn

    [SerializeField] Rigidbody2D rb; //enemy rigidbody
    [SerializeField] Transform groundCheckPos; //object ground detection
    [SerializeField] LayerMask groundLayer; //layermask name
    [SerializeField] Collider2D bodyCollider; //enemy collider

    private void Start()
    {
        enemyPatrol = true; //set status pratrol true
    }

    private void Update()
    {
        // check if enemy patrol = true, enemy will move
        if (enemyPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        // check if enemy patrol groundCheckPos = true 
        if (enemyPatrol)
        {
            enemyTurn = !Physics2D.OverlapCircle(groundCheckPos.position, radius, groundLayer);
        }
    }

    private void Patrol()
    {
        if (enemyTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }

        // make enemy move
        // rb.velocity = new Vector2(enemySpeed * Time.deltaTime, rb.velocity.y);
        rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
    }

    // membalikkan enemy
    private void Flip()
    {
        enemyPatrol = false; //set enemy status patrol false
        // tranfom localScale.x by -1
        transform.Rotate(0, -180, 0); //rotate enemy
        enemySpeed *= -1;
        enemyPatrol = true; //set enemy status patrol true
    }
}
