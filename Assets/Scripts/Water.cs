using UnityEngine;

public class Water : MonoBehaviour 
{
    private Rigidbody2D rigidbody2D;
    private AudioSource audio;
    [SerializeField]
    private float speed = 15F;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameStates.IsPaused)
            audio.enabled = false;
        else
            audio.enabled = true;
        
        MoveUp(speed);
    }
    
    private void MoveUp(float speed)
    {
        if (GameStates.IsWonCurrentLevel)
        {
            audio.Stop();
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