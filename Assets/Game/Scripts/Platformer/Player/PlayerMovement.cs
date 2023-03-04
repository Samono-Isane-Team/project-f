using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Variable")]
    [SerializeField] float speedPlayer;
    [SerializeField] float jumpPlayer;

    [SerializeField] LayerMask jumpableGround;

    private float dirX;
    private bool flip = true;
    private enum MovementState { idle, running, jumping, falling };

    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private GameObject karakter;


    private void Update()
    {
        MovePlayer();

        JumpPlayer();

        UpdateAnimateState();
    }

    // * cara player bergerak
    private void MovePlayer()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speedPlayer, rb.velocity.y);
        Debug.Log(Input.GetAxisRaw("Horizontal"));
    }

    // * mengatur cara player lompat
    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPlayer);
        }
    }

    // * cek player apakah menyentuh tanah?
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    // * mengatur pergantian animasi
    private void UpdateAnimateState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            if (!flip)
            {
                FlipCharacter();
            }
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            if (flip)
            {
                FlipCharacter();
            }
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    // * flip character
    private void FlipCharacter()
    {
        flip = !flip;
        karakter.transform.Rotate(0, 180, 0);
    }
}
