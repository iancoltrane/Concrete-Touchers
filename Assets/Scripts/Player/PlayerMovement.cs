using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float tagTime = .5f;
    
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    public GameObject tagPoint;
    public float radius;
    public LayerMask enemies;
    public float damage;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 3f;

    private enum MovementState
    {
        idle,
        moving,
        ollie,
        falling,
        doubleJump
    }

    private Coroutine _tagCoroutine;
    private bool _doubleJumped;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        var grounded = IsGrounded();
        
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (!_doubleJumped)
            {
                _doubleJumped = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        else if (grounded)
        {
            _doubleJumped = false;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.moving;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.moving;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_tagCoroutine != null) StopCoroutine(_tagCoroutine);
            
            _tagCoroutine = StartCoroutine(CoTag());
        }

        if (rb.velocity.y > .1f)
        {
            state = _doubleJumped ? MovementState.doubleJump : MovementState.ollie;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private IEnumerator CoTag()
    {
        tag();
        
        yield return new WaitForSeconds(tagTime);
        
        endTag();
    }

    private void tag()
    {
        anim.SetBool("isTagging", true);
        
        Collider2D[] enemy = Physics2D.OverlapCircleAll(tagPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Tag enemy");
            enemyGameObject.GetComponent<Health>().health -= damage;
        }
    }

    private void endTag()
    {
        anim.SetBool("isTagging", false);
        _tagCoroutine = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(tagPoint.transform.position, radius);
    }
}