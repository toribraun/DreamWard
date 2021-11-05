using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat : Unit
{
    [SerializeField]
    private float speed = 40F;
    [SerializeField]
    private float jumpforce = 90F;

    private bool isGroundNear;
    private bool isWallNear;
    private bool isPlatformNear;
    private bool doubleJumped;
    private bool turnedRight = true;

    private Rigidbody2D rigitbody;
    private Animator animator;
    private BoxCollider2D collider;
    private Vector2 standingPoint;
    private Vector2 boxSize = new Vector2 { x = 7.39F, y = 0.1F };

    private CatState State
    {
        get { return (CatState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        GameStates.IsWonCurrentLevel = false;
        rigitbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        GetStandingPoint();
        CheckGround();
        if (isGroundNear)
        {
            doubleJumped = false;
        }
        else SetFallState();
    }

    private void Update()
    {
        if (isGroundNear)
            Idle();
        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckAndJump();
        }
    }

    public void Idle()
    {
        if (turnedRight)
            State = CatState.IdleRight;
        else State = CatState.IdleLeft;
    }

    public void Run()
    {
        if (Input.GetAxis("Horizontal") >= 0)
        {
            turnedRight = true;
            State = CatState.RunRight;
        }
        else
        {
            turnedRight = false;
            State = CatState.RunLeft;
        }
        if (!isGroundNear)
            SetFallState();
        Move(Input.GetAxis("Horizontal"), speed);
    }

    public void SetFallState()
    {
        if (turnedRight)
        {
            if (rigitbody.velocity.y >= jumpforce / 2)
                State = CatState.JumpRight;
            else if (rigitbody.velocity.y < -0.5)
                State = CatState.FallRight;
            else if (Math.Abs((int)State) < 3)
                State = CatState.FallRight;
        }
        else
        {
            if (rigitbody.velocity.y >= jumpforce / 2)
                State = CatState.JumpLeft;
            else if (rigitbody.velocity.y < -0.5)
                State = CatState.FallLeft;
            else if (Math.Abs((int)State) < 3)
                State = CatState.FallLeft;
        }
    }
    
    public void Jump()
    {
        State = turnedRight ? CatState.JumpRight : CatState.JumpLeft;
        rigitbody.velocity = Vector3.zero;
        rigitbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        isPlatformNear = false;
    }

    private void CheckAndJump()
    {
        if (isGroundNear)
        {
            Jump();
        }
        else if (!doubleJumped)
        {
            doubleJumped = true;
            Jump();
        }
    }

    private void GetStandingPoint()
    {
        standingPoint.x = collider.bounds.center.x;
        standingPoint.y = transform.position.y - 7.35F;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(standingPoint, boxSize, 0);
        isWallNear = colliders.Any(c => c.CompareTag("Wall"));
        isPlatformNear = colliders.Any(c => c.CompareTag("Destroyable") || c.CompareTag("Static"));
        isGroundNear = isPlatformNear || isWallNear && isPlatformNear;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Finish") && !GameStates.IsWonCurrentLevel)
        {
            GameStates.IsWonCurrentLevel = true;
            Jump();
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5F);
        SceneManager.LoadScene("MenuWin");
    }
    
    
    public override void Die()
    {
        SceneManager.LoadScene("Lose");
    }
    
    private IEnumerator LoseGame()
    {
        yield return new WaitForSeconds(1F);
    }
}
