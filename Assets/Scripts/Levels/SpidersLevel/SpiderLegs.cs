using UnityEngine;

public class SpiderLegs : MonoBehaviour 
{
    [SerializeField]
    private float speed = 9F;
    private int rotateLegDirection = -1;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0.3f;
    }

    private void Update()
    {
        MoveRight(speed);
        if (GameStates.IsWonCurrentLevel)
            animator.enabled = false;
    }
    
    private void MoveRight(float speed)
    {
        // transform.rotation = Quaternion.RotateTowards(
        //     transform.rotation,
        //     new Quaternion(
        //         transform.rotation.x,
        //         transform.rotation.y,
        //         transform.rotation.z + rotateLegDirection * 0.01F,
        //         transform.rotation.w ), speed * Time.deltaTime);
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