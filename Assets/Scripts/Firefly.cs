using UnityEngine;

public class Firefly : MonoBehaviour
{
    private Collider2D cat;
    
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(state is State.Free)) return;
        if (other.collider.CompareTag("Player"))
        {
            other.collider.GetComponent<Cat>().GatheredFirefly = this;
            cat = other.collider;
            Destroy(GetComponent<Collider2D>());
            NextState();
        }
    }
}
