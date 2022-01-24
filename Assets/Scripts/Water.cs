using UnityEngine;

public class Water : MonoBehaviour 
{
    private AudioSource audio;
    private Animator animator;
    private float speed = 7F;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        InvokeRepeating("SpeedUp", 0.0f, 0.1f);
    }

    private void Update()
    {
        if (GameStates.IsPaused)
            audio.enabled = false;
        else
            audio.enabled = true;
        
        MoveUp(speed);
    }

    private void SpeedUp()
    {
        speed += 0.03F;
    }
    
    private void MoveUp(float speed)
    {
        if (GameStates.IsWonCurrentLevel)
        {
            audio.Stop();
            animator.SetBool("WaterUp", false);
            transform.position = Vector3.MoveTowards(
                transform.position, 
                transform.position - transform.up, speed / 2 * Time.deltaTime);
        }
        else 
            transform.position = Vector3.MoveTowards(
            transform.position, 
            transform.position + transform.up, speed * Time.deltaTime);
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