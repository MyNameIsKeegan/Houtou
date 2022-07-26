using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSponge : MonoBehaviour
{
    // Simple component for detecting when a bullet sponge gets hit by an opposing bullet
    private Collider2D coll;
    private Health health;
    private string opposingTag;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
        health = GetComponentInParent<Health>();
    }

    void OnEnable()
    {
        if (gameObject.CompareTag("Friendly")) opposingTag = "Enemy";
        else opposingTag = "Friendly";
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(opposingTag))
        {
            health.DoDelta(-1);
        }
    }
}
