using UnityEngine;

public class Spider : MonoBehaviour
{
    [HideInInspector]
    public bool IsDead;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            var player = other.collider.GetComponent<Cat>();
            player.Die();
        }
    }   
}
