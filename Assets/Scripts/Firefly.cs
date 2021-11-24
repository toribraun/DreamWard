using UnityEngine;

public class Firefly : MonoBehaviour
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

    private void Update()
    {
        if (state is State.OnCat)
        {
            transform.position = cat.transform.position + new Vector3(5, 5);
        }
        if (state is State.InLamp)
        {
            transform.position = lampPosition;
        }
    }

    public void NextState()
    {
        state += 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
