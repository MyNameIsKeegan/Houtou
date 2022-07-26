using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // General purpose health component, use on ANYTHING that has health.
    public float maxHealth = 1;
    public float currentHealth = 1;
    public float deathHealth = 0;
    [Space]
    public bool godMode = false;

    // Delta is the only required argument, but please specifiy source when you can for cleanliness.
    public void DoDelta(float delta, GameObject source = null)
    {
        // Ignore if we're in god mode
        if (godMode) return;

        currentHealth += delta;
    }

    void Update()
    {
        // Ignore everything else if we're in god mode
        if (godMode) return;

        if (currentHealth <= deathHealth) Die();
    }

    public void Die()
    {
        //TODO make proper death code or script
        PrefabManager.Instance.Spawn("deathfx", transform.position);
        
        Debug.Log("\"" + gameObject.name + "\" has been suuced dry.");
        
        Destroy(gameObject);
    }

    public void SuperGodMode()
    {
        currentHealth = maxHealth;
        godMode = true;
    }
}
