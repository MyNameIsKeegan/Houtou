using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // SKY: This should act more as an control interface to other, more general components that we'll write. 
    // I don't want too many custom things in here if we don't need them to be.

    private Shooter shooter;

    // Publics

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Z))
        {
            shooter.TryBoom();
        }
    }
}
