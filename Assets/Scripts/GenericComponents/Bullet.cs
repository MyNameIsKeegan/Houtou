using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bullet : MonoBehaviour
{
    // General purpose bullet/projectile component. Stats planned to be calculated based on the Shooter component it comes from when shot/launched.
    // We should also have some preset values and safeties though, in case we need to spawn a bullet standalone or something.
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Light2D glow;

    public Vector2 direction = new Vector2(0, 1);
    public float speed = 1500;
    public float damage = 1f;
    public float lifetime = 4f;
    [Space]
    public bool isFriendly = true;
    [Space]
    public GameObject source;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        glow = GetComponent<Light2D>();
    }
    
    // Using OnEnable here to prepare for object pooling
    private void OnEnable()
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse); // ForceMode2D.Impulse applies the force instantly
        Invoke("EmergencyDie", lifetime);

        if (isFriendly) MakeFriendly();
        else MakeEnemy();
    }

    // Pooled bullets must have their velocity reset
    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }

    // Setting as public in case we wanna do some sort of bullet reflection or something
    public void MakeFriendly()
    {
        sprite.color = Color.blue;
        glow.color = Color.blue;
        gameObject.tag = "Friendly";
    }

    public void MakeEnemy()
    {
        sprite.color = Color.red;
        glow.color = Color.red;
        gameObject.tag = "Enemy";
    }

    // Disabling for now, may be better to detect bullets on applicable objects rather than the other way around
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {  
        // No need to check objects anymore, as long as we keep our layers clean we can only hit objects we're supposed to.
        if (other.TryGetComponent(out Health health)) health.DoDelta(-damage, source);

        Destroy(gameObject);
    }
    */

    private void EmergencyDie()
    {
        Debug.LogWarning("Bullet existed for more than " + lifetime.ToString() + " second(s), destroying...");
        Destroy(gameObject);
    }
}
