using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Cat>();
        if (player is null) return;
        if (other.CompareTag("Player"))
        {
            player.speed = 20F;
            player.jumpforce = 60F;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<Cat>();
        if (player is null) return;
        if (other.CompareTag("Player"))
        {
            player.speed = 40F;
            player.jumpforce = 90F;
        }
    }
}