using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFool : MonoBehaviour
{
    private BoxCollider2D bc;

    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.CompareTag("playerBullet"))
    //     {
    //         // print("ho");
    //         GetComponent<ParticleSystem>().Play();

    //         Destroy(other.gameObject);
            
    //         if (TryGetComponent(out Health health))
    //         {
    //             health.DoDelta(-1);
    //         }
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
