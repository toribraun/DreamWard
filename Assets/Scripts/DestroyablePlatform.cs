using System.Collections;
using UnityEngine;

public class DestroyablePlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private float delay = 0.5F;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }

        if (other.collider.CompareTag("Static"))
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(delay);
        // rigidbody2D.isKinematic = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        // GetComponent<Collider2D>().isTrigger = true;
        yield return 0;
    }
}
