using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    // All this does is delete an object after it exists for a certain period of time. 
    // Later we'll probably either build this into each FX prefab, or update this component a bit to be
    //more useful.
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
