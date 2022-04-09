using UnityEngine;

public class SpiderLegs : MonoBehaviour 
{
    // private AudioSource audio;
    // private Animator animator;
    private float speed = 3F;
    private int rotateLegDirection = -1;

    private void Awake()
    {
        // audio = GetComponent<AudioSource>();
        // animator = GetComponent<Animator>();
        // InvokeRepeating("ChangeRotateLegDirection", 0.01f, 1f);
    }

    private void Update()
    {
        // if (GameStates.IsPaused)
        //     audio.enabled = false;
        // else
        //     audio.enabled = true;
        
        MoveRight(speed);
    }

    private void ChangeRotateLegDirection()
    {
        rotateLegDirection *= -1;
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
            // audio.Stop();
            // animator.SetBool("WaterUp", false);
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