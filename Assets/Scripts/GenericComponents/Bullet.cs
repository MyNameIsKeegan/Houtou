using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // General purpose bullet/projectile component. Stats planned to be calculated based on the Shooter component it comes from when shot/launched.
    // We should also have some preset values and safeties though, in case we need to spawn a bullet standalone or something.
    private Rigidbody2D rb;
    
    public Vector2 direction = new Vector2(0, 1);
    public float speed = 1500;
    public float damage = 1f;
    public float lifetime = 10f;
    [Space]
    public GameObject source;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void Start()
    {
        rb.AddForce(direction * speed);
        Invoke("EmergencyDie", lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  
        // No need to check objects anymore, as long as we keep our layers clean we can only hit objects we're supposed to.
        if (other.TryGetComponent(out Health health)) health.DoDelta(-damage);

        Destroy(gameObject);
    }

    void EmergencyDie()
    {
        Debug.LogWarning("Bullet existed for more than 10 seconds, destroying...");
        Destroy(gameObject);
    }
}
