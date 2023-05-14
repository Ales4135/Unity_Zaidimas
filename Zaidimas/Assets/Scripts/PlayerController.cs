using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))]

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float airWalk = 5f;
    public float jumpImpulse = 10f;
    Vector2 moveInput;
    TouchingDirections touchingDirections;
    Damageable damageable;
    [SerializeField] private AudioClip throwKnifeSound;
    [SerializeField] private AudioClip swordSwingSound;
    [SerializeField] private AudioClip jumpSound;

    public Vector3 respawnPoint;
    public static Vector2 lastCheckpoint;

    public float CurrentSpeed { get 
        {
            if (CanMove)
            {

                if (IsMoving && !touchingDirections.IsOnWall)
                {
                    if (touchingDirections.IsGrounded)
                    {
                        if (isRunning)
                        {
                            return runSpeed;
                        }
                        else
                        {
                            return walkSpeed;
                        }
                    }
                    else
                    {
                        // Movement in air
                        return airWalk;
                    }
                }
                else
                {
                    // Idle speed
                    return 0;
                }
            }
            else 
            {
                // Movement locked
                return 0;
            }
        } }

    private bool _isMoving = false;

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    private bool _isRunning = false;

    public bool isRunning
    {
        get
        {
            return _isRunning;
        }
        set 
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    public bool _isFacingRight = true;

    public bool CanMove { get { return animator.GetBool(AnimationStrings.canMove); } }

    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }

    Rigidbody2D rb;
    Animator animator;
    float x;
    AudioSource audioSrc;
    public bool isFacingRight { get { return _isFacingRight; } private set 
        { 
            if(_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        } }

    public void Awake()//private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
        audioSrc = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * walkSpeed;
        rb.velocity = new Vector2(x, rb.velocity.y);
        PlayFootstepAudio();
    }

    private void FixedUpdate()
    {
        if (!damageable.LockVelocity)
        {
            rb.velocity = new Vector2(moveInput.x * CurrentSpeed, rb.velocity.y);
        }
       

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (IsAlive)
        {
            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        }
        else
        {
            IsMoving = false;
        }

    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && ! isFacingRight)
        {
            isFacingRight = true;
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            isFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isRunning= true;
        }else if (context.canceled)
        {
            isRunning= false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // todo check if alive
        if (context.started && touchingDirections.IsGrounded && CanMove)
        {
            SoundManager.instance.PlaySound(jumpSound);
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        SoundManager.instance.PlaySound(swordSwingSound);
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }

    public void OnRangedAttack(InputAction.CallbackContext context)
    {
        SoundManager.instance.PlaySound(throwKnifeSound);
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.rangedAttackTrigger);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }

    void PlayFootstepAudio()
    {
        if(IsMoving == true && touchingDirections.IsGrounded)
        {
            if(!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
        }
        else
            audioSrc.Stop();
    }
}
