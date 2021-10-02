using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public void Move(float direction, float speed)
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            transform.position + transform.right * direction, 
            speed * Time.deltaTime);
    }
}
