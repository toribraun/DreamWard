using UnityEngine;

public class Lamp : MonoBehaviour
{
    [HideInInspector]
    public DarknessLevel LevelManager;
    
    public int FirefliesLeft;
    public FirefliesLeftScore firefliesLeftScore;
    public Animator animator;
    
    [SerializeField]
    private AudioSource sound;

    private Cat player;
    private Bounds bounds;

    private void Start()
    {
        bounds = GetComponent<Collider2D>().bounds;
        sound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<Cat>();
        if (player is null) return;
        if (other.CompareTag("Player") && LevelManager.GatheredFirefly != null)
        {
            sound.Play();
            LevelManager.GatheredFirefly.lampPosition = new Vector3(bounds.min.x, bounds.center.y);
            LevelManager.GatheredFirefly.NextState();
            LevelManager.GatheredFirefly = null;
            FirefliesLeft--;
            firefliesLeftScore.UpdateFirefliesLeftScore(LevelManager.fireflies.Length - FirefliesLeft - 1);
            if (FirefliesLeft == 0)
            {
                player.Win();
            }
        }
    }
}
