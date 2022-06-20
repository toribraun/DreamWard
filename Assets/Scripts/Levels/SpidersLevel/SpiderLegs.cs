using UnityEngine;

public class SpiderLegs : MonoBehaviour 
{
    [SerializeField]
    private float speed = 9F;
    private int rotateLegDirection = -1;
    private Animator animator;
    private bool hasAnimator;

    private void Awake()
    {
        hasAnimator = TryGetComponent(out animator);
        if (hasAnimator)
            animator.speed = 0.3f;
    }

    private void Update()
    {
        MoveRight(speed);
        if (hasAnimator && GameStates.IsWonCurrentLevel)
            animator.enabled = false;
    }
    
    private void MoveRight(float speed)
    {
        if (GameStates.IsWonCurrentLevel)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                transform.position - transform.right, speed / 2 * Time.deltaTime);
        }
        else 
            transform.position = Vector3.MoveTowards(
                transform.position, 
                transform.position + transform.right, speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            var player = other.collider.GetComponent<Cat>();
            player.Die();
        }
    }

}