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

    public Firefly GatheredFirefly;

    private Rigidbody2D rigidbody;
    private Animator animator;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    private Vector2 standingPoint;
    private Vector2 boxSize = new Vector2 { x = 7.39F, y = 0.1F };
    private float xScale; //это должно быть чем-то типа константы или readonly, но я устала. Не трогайте пожалуйста это поле

    private CatState State
    {
        get { return (CatState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        GameStates.IsWonCurrentLevel = false;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        xScale = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        GetStandingPoint();
        CheckGround();
        if (isGroundNear)
        {
            doubleJumped = false;
        }
        else
        {
            SetFallState();
        }
    }

    private void Update()
    {
        if (PauseMenu.IsPaused) return;
        if (isGroundNear)
            State = CatState.Idle;
        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckAndJump();
        }
    }

    public void Run()
    {
        State = CatState.Run;
        if (!isGroundNear)
            SetFallState();
        var localScale = transform.localScale; //Это всё чтобы перевернуть кота
        if (Input.GetAxis("Horizontal") < 0)
            localScale.x = -xScale;
        else localScale.x = xScale;
        transform.localScale = localScale; //Да, вот до сюда. По идее переворачивает весь объект, не только спрайт
        Move(Input.GetAxis("Horizontal"), speed);
    }

    public void SetFallState()
    {
        State = CatState.Jump;
        animator.SetFloat("vSpeed", rigidbody.velocity.y);
    }
    
    public void Jump()
    {
        State = CatState.Jump;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
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
