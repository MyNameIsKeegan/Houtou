using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 1;
    public float currentHealth = 1;
    public float deathHealth = 0;
    [Space]
    public bool godMode = false;
    [Space]
    public GameObject deathFX;
    

    // Delta is the only required argument, but please specifiy source when you can for cleanliness.
    public void DoDelta(float delta, GameObject source = null, bool bypassClamps = false)
    {
        // Ignore if we're in god mode
        if (godMode) return;

        currentHealth += delta;
    }

    void Update()
    {
        // Ignore everything else if we're in god mode
        if (godMode) return;

        if (currentHealth <= deathHealth)
        {
            Die();
        }
    }

    public void Die()
    {
        //TODO make proper death code or script
        Debug.Log(gameObject.name + " has been deaded!");
        
        Instantiate(deathFX).transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }

    public void SuperGodMode()
    {
        currentHealth = maxHealth;
        godMode = true;
    }
}
