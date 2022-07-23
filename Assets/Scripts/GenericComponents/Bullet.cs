using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float sped;
    public float damage = 1f;
    public float lifetime = 1f;
    [Space]
    public GameObject source;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void Start()
    {
        rb.AddForce(new Vector2(0, sped));
        Invoke("Die", lifetime);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Terrible way to figure out if we're hitting the player's bullet sponge.
        if (!other.CompareTag("BulletSponge") || other.gameObject == source.transform.Find("PlayerBulletSponge").gameObject) return; // Bullets shouldn't hit their source!

        if (other.TryGetComponent(out Health health)) health.DoDelta(-damage);

        print(other.name);
        Die();
    }
}
