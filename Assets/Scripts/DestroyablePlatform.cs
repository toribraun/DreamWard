using System.Collections;
using UnityEngine;

public class DestroyablePlatform : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float delay = 0.5F;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        // GetComponent<Collider2D>().isTrigger = true;
        yield return 0;
    }
}
