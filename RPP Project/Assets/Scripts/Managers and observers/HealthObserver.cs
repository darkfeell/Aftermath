using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthObserver : MonoBehaviour
{
    public static event Action<int> healthGainedEvent;

    public static void OnHealthGainEvent(int health)
    {
        healthGainedEvent?.Invoke(health);
    }
}
