using UnityEngine;

public class Firefly : Unit
{
    private Cat cat;

    private enum State
    {
        Free,
        OnCat,
        InLamp
    }

    private State state = State.Free;

    public Vector3 lampPosition;
    
    [SerializeField]
    private AudioSource sound;
    
    // For Following Route
    [SerializeField] 
    private Transform[] routes;

    private int routeToGo;
    private float tParam;
    private Vector3 newPosition;
    private float speedModifier;
    private Vector3 basePosition;

    private void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.75f;
        basePosition = transform.position;
        sound = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (state is State.Free)
        {
            Move(basePosition);
        }
        
        if (state is State.OnCat)
        {
            Move(cat.transform.position + new Vector3(5, 5));
        }

        if (state is State.InLamp)
        {
            Move(lampPosition);
        }
    }

    private void Move(Vector3 startPosition)
    {
        var p0 = routes[routeToGo].GetChild(0).position;
        var p1 = routes[routeToGo].GetChild(1).position;
        var p2 = routes[routeToGo].GetChild(2).position;
        var p3 = routes[routeToGo].GetChild(3).position;

        tParam += Time.deltaTime * speedModifier;

        newPosition = Mathf.Pow(1 - tParam, 3) * p0 + 
                      3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                      3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + 
                      Mathf.Pow(tParam, 3) * p3;
            
        transform.position = startPosition + newPosition;
        if (tParam >= 1)
        {
            tParam = 0f;
            routeToGo += 1;
            if (routeToGo > routes.Length - 1)
                routeToGo = 0;
        }
    }

    public void NextState()
    {
        state += 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        sound.Play();
        cat = other.GetComponent<Cat>();
        if (!(state is State.Free)) return;
        if (other.CompareTag("Player"))
        {
            if (cat.GatheredFirefly != null) return;
            cat.GatheredFirefly = this;
            Destroy(GetComponent<Collider2D>());
            NextState();
        }
    }
}
