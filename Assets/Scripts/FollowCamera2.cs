using System;
using UnityEngine;

public class FollowCamera2 : MonoBehaviour 
{
    [SerializeField] 
    private float speed = 7F;
    [SerializeField] 
    private Transform player;
    
    void Awake()
    {
        if (!player)
            player = FindObjectOfType<Cat>().transform;

    }

    private void Update()
    {
        if (Math.Abs(player.position.y - transform.position.y) > 1e-9)
        {
            var position = player.position;
            position.z = -10F;
        
            if (player.position.y < -80)
                position.y = 0;
            position.y *= 0.9F;
            
            transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
        }
    }
}
