using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
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
            var newPos = transform.position;
            newPos.y = player.position.y;
            transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
        }
    }
}
