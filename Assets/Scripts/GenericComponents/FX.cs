using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    public float lifetime = 3f;
    void Start()
    {
        Invoke("kys", lifetime);
    }

    void kys()
    {
        Destroy(gameObject);
    }
}
