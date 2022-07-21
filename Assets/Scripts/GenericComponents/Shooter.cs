using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform bulletOrifice;
    private float shootCooldown = 0f;
    public float shootsPerSecond = 10;

    public void Boom() {
        GameObject inst = PrefabManager.Instance.Spawn("bullet", bulletOrifice.transform.position);
        inst.GetComponent<Bullet>().source = gameObject;
    }

    public void TryBoom()
    {
        if (shootCooldown <= 0)
        {
            Boom();
            shootCooldown = 1 / shootsPerSecond;
        }
    }

    void Update()
    {
        if (shootCooldown > 0) 
        {
            shootCooldown -= Time.deltaTime;
            shootCooldown = Mathf.Max(shootCooldown, 0);
        }
    }
}
