using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelMovement : MonoBehaviour
{
    public enum MovementStates
    {
        Idle,
        Running,
        Jumping,
    }
    public enum FacingDirection
    {
        Right,
        Left
    }

    [Header("Movement values")]
    public float movementSpeed;
    public float jumpForce;

    [Header("Raycast length and layerMask")]
    public float isGroundedRayLength;
    public LayerMask platformLayerMask;

    [Header("Movement States")]
    public MovementStates movementState;
    public FacingDirection facingDirection;

    //public ParticleSystem dust;

    private Rigidbody2D rigidBody2D;
    private BoxCollider2D boxCollider2D;
    private PlayerCombatAnimationContoller animController;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animController = GetComponent<PlayerCombatAnimationContoller>();
    }

    private void Update()
    {
        HandleJumping();
    }
    private void FixedUpdate()
    {
        HandleMovement();
        SetCharacterState();
        SetCharacterDirection();
        PlayAnimationsBasedOnState();
    }

    private void HandleMovement()
    {
        //rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        //if (Input.GetKey(KeyCode.A))
        //{
        //    rigidBody2D.velocity = new Vector2(-movementSpeed, rigidBody2D.velocity.y);

        //    if (IsGrounded())
        //    {
        //        //CreateDust();
        //    }
        //}
        //else
        //{
        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        rigidBody2D.velocity = new Vector2(+movementSpeed, rigidBody2D.velocity.y);
        //        if (IsGrounded())
        //        {
        //            //CreateDust();
        //        }

        //    }
        //    else //NO KEYS PRESSED
        //    {
        //        rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
        //        rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        //    }
        //}

        float h = Input.GetAxisRaw("Horizontal");
        rigidBody2D.velocity = new Vector2(h * movementSpeed, rigidBody2D.velocity.y);
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rigidBody2D.velocity = Vector2.up * jumpForce;
            //MusicManager.PlaySound("Jump");
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
            boxCollider2D.bounds.size, 0f, Vector2.down,
            isGroundedRayLength, platformLayerMask);
        return raycastHit2D.collider != null;
    }

    private void SetCharacterState()
    {
        if (IsGrounded())
        {
            if (rigidBody2D.velocity.x == 0)
            {
                movementState = MovementStates.Idle;
            }
            else if (rigidBody2D.velocity.x > 0)
            {
                facingDirection = FacingDirection.Right;
                movementState = MovementStates.Running;
            }
            else if (rigidBody2D.velocity.x < 0)
            {
                facingDirection = FacingDirection.Left;
                movementState = MovementStates.Running;
            }
        }
        else
        {
            movementState = MovementStates.Jumping;
        }
    }

    private void SetCharacterDirection()
    {
        switch (facingDirection)
        {
            case FacingDirection.Right:
                transform.localScale = new Vector2(0.9f, 0.9f);
                break;
            case FacingDirection.Left:
                transform.localScale = new Vector2(-0.9f, 0.9f);
                break;
        }
    }

    private void PlayAnimationsBasedOnState()
    {
        switch (movementState)
        {
            case MovementStates.Idle:
                animController.PlayIdleAnim();
                break;
            case MovementStates.Running:
                animController.PlayRunningAnim();
                break;
            case MovementStates.Jumping:
                animController.PlayJumpingAnim();
                break;
            default:
                break;
        }
    }

    //private void CreateDust()
    //{
    //    dust.Play();
    //}
}
