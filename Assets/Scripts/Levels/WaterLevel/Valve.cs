using System;
using UnityEngine;

public class Valve : MonoBehaviour
{
    public Animator animator { get; private set; }
    public Cat player;
    
    private Collider2D collider;

    void Awake()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && !GameStates.IsWonCurrentLevel)
        {
            GameStates.IsWonCurrentLevel = true;
            collider.GetComponent<AudioSource>().Play();
            player.Win();
        }
    }
}