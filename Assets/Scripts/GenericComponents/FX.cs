using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("kys", 3);
    }

    void kys()
    {
        Destroy(gameObject);
    }
}
