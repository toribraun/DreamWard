using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Cat cat;
    private int firefliesLeft = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        cat = other.GetComponent<Cat>();
        if (cat is null) return;
        if (other.CompareTag("Player") && cat.GatheredFirefly != null)
        {
            cat.GatheredFirefly.lampPosition = transform.position;
            cat.GatheredFirefly.NextState();
            firefliesLeft--;
        }
    }
}
