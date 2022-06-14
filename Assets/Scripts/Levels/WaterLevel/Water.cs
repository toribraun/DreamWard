using UnityEngine;

public class Water : MonoBehaviour 
{
    private AudioSource audio;
    private Animator animator;
    public float Speed;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        InvokeRepeating("SpeedUp", 0.0f, 0.1f);
    }

    private void Update()
    {
        audio.enabled = !GameStates.IsPaused;

        MoveUp(Speed);
    }

    private void SpeedUp()
    {
        Speed += 0.03F;
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