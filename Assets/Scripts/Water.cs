using UnityEngine;

public class Water : MonoBehaviour 
{
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private float speed = 15F;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!GameStates.IsWonCurrentLevel)
            MoveUp(speed);
    }
    
    private void MoveUp(float speed)
    {
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