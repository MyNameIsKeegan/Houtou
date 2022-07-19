using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float lifetime = 1f;
    public float sped;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(new Vector2(0, sped));

        Invoke("Die", lifetime);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
