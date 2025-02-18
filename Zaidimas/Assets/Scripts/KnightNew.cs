using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightNew : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float waypointReachedDistance = 0.5f;
    public DetectionZone AttackDetectionZone;
    public Collider2D deathCollider;
    public List<Transform> waypoints;

    Animator animator;
    Rigidbody2D rb;
    Damageable damageable;

    Transform nextWaypoint;

    int waypointNum = 0;

    public bool _hasTarget = false;


    public bool HasTarget
    {
        get
        {
            return _hasTarget;
        }
        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public bool CanMove
    {
        get { return animator.GetBool(AnimationStrings.canMove); }
    }



    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        damageable = GetComponent<Damageable>();
    }

    private void Start()
    {
        nextWaypoint = waypoints[waypointNum];
    }

    private void OnEnable()
    {
        //damageable.damageableDeath += OnDeath();
    }

    public float AttackCooldown
    {
        get
        {
            return animator.GetFloat(AnimationStrings.attackCooldown);
        }
        private set
        {
            animator.SetFloat(AnimationStrings.attackCooldown, Mathf.Max(value, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        HasTarget = AttackDetectionZone.detectedColliders.Count > 0;

        if (AttackCooldown > 0)
        {
            AttackCooldown -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        if (damageable.IsAlive)
        {
            if (CanMove)
            {
                Move();
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void Move()
    {
        //Fly to next waypoint
        Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;

        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = directionToWaypoint * MoveSpeed;

        UpdateDirection();

        if (distance <= waypointReachedDistance)
        {
            waypointNum++;

            if (waypointNum >= waypoints.Count)
            {
                waypointNum = 0;
            }

            nextWaypoint = waypoints[waypointNum];
        }

    }

    private void UpdateDirection()
    {
        Vector3 locScale = transform.localScale;

        if (transform.localScale.x > 0)
        {
            //facing the right
            if (rb.velocity.x < 0)
            {
                //Flip
                transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
        else
        {
            if (rb.velocity.x > 0)
            {
                //Flip
                transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
    }

    public void OnDeath()
    {
        rb.gravityScale = 2f;
        rb.velocity = new Vector2(0, rb.velocity.y);
        deathCollider.enabled = true;
    }
}
