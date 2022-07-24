using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Generic shooter component, I'm thinking we make this a Weapon component instead, in case we wanna do anything like a melee attack.
    public Transform bulletOrifice; // Orfice may not be necessary, offsets may be a better idea.
    public float shootsPerSecond = 10;
    [Space]
    [Header("Bullet Stats")]
    public float bulletDamage = 1;
    public float bulletSpeed = 1500;

    private bool isShooting;

    public void Boom() { // Spawns the bullet no matter what
        GameObject inst = PrefabManager.Instance.Spawn("bullet", bulletOrifice.transform.position);
        Bullet instBullet = inst.GetComponent<Bullet>(); // Store bullet component of the new bullet since we're messing with it a bunch

        instBullet.source = gameObject; // gameObject is the game object this shooter is attached to
        instBullet.damage = bulletDamage;
        instBullet.speed = bulletSpeed;
    }

    // Starts the shooting loop. Object won't stop shooting until StopBooming is called.
    public void StartBooming()
    {
        if (isShooting) return;

        isShooting = true;
        StartCoroutine(BoomLoop());
    }

    public void StopBooming()
    {
        if (!isShooting) return;

        isShooting = false;
        StopCoroutine(BoomLoop());
    }

    // Coroutine loop instead of checking cooldowns in Update(), kindof like a threaded version of sleep() from some other languages
    private IEnumerator BoomLoop()
    {   
        while (isShooting)
        {
            Boom();
            yield return new WaitForSeconds(1 / shootsPerSecond);
        }
    }
}
