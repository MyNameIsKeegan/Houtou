using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootersController : MonoBehaviour
{
    // Component for dealing with multiple shooters more easily
    private List<Shooter> shooters = new List<Shooter>();
    public float shooterCount = 1;

    private void Awake()
    {
        RefreshShooters();
    }

    // Controls
    public void StartBoomingAll()
    {
        shooters.ForEach(shooter => shooter.StartBooming());
    }

    public void StopBoomingAll()
    {
        shooters.ForEach(shooter => shooter.StopBooming());
    }

    public List<Shooter> GetShooters()
    {
        return shooters;
    }

    // public Shooter AddShooter()
    // {
        
    // } 

    public void RefreshShooters()
    {
        shooters.Clear();

        foreach(Shooter shooter in GetComponentsInChildren<Shooter>())
        {
            shooters.Add(shooter);
        }
    }
}
