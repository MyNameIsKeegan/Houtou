using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFool : MonoBehaviour
{
    public BoxCollider2D bc;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("playerBullet"))
        {
            // print("ho");
            GetComponent<ParticleSystem>().Play();

            Destroy(other.gameObject);
            
            if (TryGetComponent(out Health health))
            {
                health.DoDelta(-1);
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
