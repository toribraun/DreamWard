using UnityEngine;

public class Lamp : MonoBehaviour
{
    public int FirefliesLeft;
    [SerializeField] 
    public FirefliesLeftScore firefliesLeftScore;
    [SerializeField]
    private AudioSource sound;
    private Animator animator;

    private Cat cat;
    private Bounds bounds;

    private void Start()
    {
        FirefliesLeft = 6; //6
        bounds = GetComponent<Collider2D>().bounds;
        sound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
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
            firefliesLeftScore.UpdateFirefliesLeftScore(6 - FirefliesLeft - 1);
            if (FirefliesLeft == 0)
            {
                StartCoroutine(cat.EndGame(animator));
            }
        }
    }
}
