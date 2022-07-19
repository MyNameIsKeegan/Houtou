using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // SKY: This should act more as an control interface to other, more general components that we'll write. 
    // I don't want too many custom things in here if we don't need them to be.

    // SKY: I'm gonna make assumptions that we have required components here for now, we can add safety checks later if it becomes a problem.

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
            shooter.Boom();
        }
    }
}
