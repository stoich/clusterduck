using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    private Rigidbody2D b;

    void Start()
    {
        b = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void LimitSpeed() {
        
        if (GetCurrentSpeed() > DuckManager.main.terminalVelocity) {

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
        return GetCurrentSpeed() > DuckManager.main.sonicTreshold;
    }
}
