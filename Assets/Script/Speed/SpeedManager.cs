using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    private Rigidbody2D b;
    public float sonicTreshold, terminalVelocity;

    void Start()
    {
        b = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void LimitSpeed() {
        
        if (GetCurrentSpeed() > terminalVelocity) {

            SetCurrentSpeed( terminalVelocity );

        }
    
    }

    private float GetCurrentSpeed()
    {
        return b.velocity.magnitude;
    }

    private void SetCurrentSpeed(float newSpeed) {

        b.velocity = b.velocity.normalized * newSpeed;
    
    } 

    public bool IsSonic()
    {
        return GetCurrentSpeed() > sonicTreshold;
    }
}
