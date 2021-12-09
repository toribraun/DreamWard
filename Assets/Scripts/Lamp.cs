using UnityEngine;

public class Lamp : MonoBehaviour
{
    public static int FirefliesLeft;
    
    [SerializeField]
    private AudioSource sound;

    private Cat cat;
    private Bounds bounds;

    private void Start()
    {
        FirefliesLeft = 2;
        bounds = GetComponent<Collider2D>().bounds;
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        cat = other.GetComponent<Cat>();
        if (cat is null) return;
        if (other.CompareTag("Player") && cat.GatheredFirefly != null)
        {
            sound.Play();
            cat.GatheredFirefly.lampPosition = new Vector3(bounds.min.x, bounds.center.y);
            cat.GatheredFirefly.NextState();
            cat.GatheredFirefly = null;
            FirefliesLeft--;
            FirefliesLeftScore.UpdateFirefliesLeftScore();
            if (FirefliesLeft == 0)
            {
                StartCoroutine(cat.EndGame());
            }
        }
    }
}
