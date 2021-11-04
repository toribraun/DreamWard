using System.Collections;
using UnityEngine;

public class DestroyablePlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    private float delay = 0.5F;
    private bool isFalling;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            var contactPoint = other.contacts[0].point;
            var platformPositionCenter = col.bounds.center;
            if (contactPoint.y > platformPositionCenter.y)
                StartCoroutine(Fall());
        }
        else if (isFalling)
        {
            Physics2D.IgnoreCollision(other.collider, col);
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(delay);
        isFalling = true;
        // rigidbody2D.isKinematic = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        // GetComponent<Collider2D>().isTrigger = true;
        yield return 0;
    }
}
