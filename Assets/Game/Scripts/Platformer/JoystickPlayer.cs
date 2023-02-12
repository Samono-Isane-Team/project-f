using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    [Header("Movement Variable")]
    [SerializeField] float speedPlayer;
    [SerializeField] float jumpPlayer;

    [SerializeField] LayerMask jumpableGround;

    private float dirX;
    private bool flip = true;
    private enum MovementState { idle, running, jumping, falling };

    public VariableJoystick variableJoystick;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private GameObject karakter;


    private void Update()
    {
        UpdateAnimateState();
    }

    public void FixedUpdate()
    {
        MovePlayer();
    }

    // * cara player bergerak
    private void MovePlayer()
    {
        // dirX = Input.GetAxisRaw("Horizontal");
        // rb.velocity = new Vector2(dirX * speedPlayer, rb.velocity.y);
        rb.velocity = new Vector2(variableJoystick.Horizontal * speedPlayer, rb.velocity.y);
    }

    // * mengatur cara player lompat
    public void JumpPlayer()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, jumpPlayer);
        // }
        if (IsGrounded())
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
    public void UpdateAnimateState()
    {
        MovementState state;

        if (variableJoystick.Horizontal > 0f)
        {
            state = MovementState.running;
            if (!flip)
            {
                FlipCharacter();
            }
        }
        else if (variableJoystick.Horizontal < 0f)
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
