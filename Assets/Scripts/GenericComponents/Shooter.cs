using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform bulletOrifice;
    public GameObject bullet;

    public void Boom() {
        GameObject inst = Instantiate(bullet);
        inst.transform.position = bulletOrifice.transform.position;
    }
}
