using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private float speed = 7F;

    public Transform player;
    
    [HideInInspector]
    public float LeftBorder;
    [HideInInspector]
    public float RightBorder;
    [HideInInspector]
    public float TopBorder;
    [HideInInspector]
    public float BottomBorder;
    
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
            // position.y *= 0.9F;

            position.x = Mathf.Clamp(position.x, LeftBorder, RightBorder);
            position.y = Mathf.Clamp(position.y, BottomBorder, TopBorder);
            transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
        }
    }
}