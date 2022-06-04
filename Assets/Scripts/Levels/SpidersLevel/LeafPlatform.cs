using System.Collections;
using UnityEngine;

public class LeafPlatform : MonoBehaviour
{
    private GameObject platform;
    private Rigidbody2D rb;
    private Collider2D col;
    private Animator anim;
    private float delay = 0.0F;
    public bool isFalling;

    private void Start()
    {
        platform = GameObject.FindWithTag("Destroyable");
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            var contactPoint = other.contacts[0].point;
            var platformPositionCenter = col.bounds.center;
            rb.centerOfMass = platformPositionCenter;
            if (contactPoint.y > platformPositionCenter.y)
                StartCoroutine(Fall());
        }
        else
        {
            Physics2D.IgnoreCollision(other.collider, col);
        }
        if (isFalling)
        {
            Physics2D.IgnoreCollision(other.collider, col);
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(delay);
        isFalling = true;
        col.isTrigger = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.velocity = Vector3.zero;
        anim.Play("LeafFade");
        yield return 0;
    }
}
