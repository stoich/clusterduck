using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    private Rigidbody2D b;
    public Vector3 cachedVelocity, currentVelocity;


    void Start()
    {
        b = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        cachedVelocity = currentVelocity;
        currentVelocity = b.velocity;
        LimitSpeed();
    }

    private void LimitSpeed() {
        
        if (GetSpeed() > DuckManager.main.terminalVelocity) {

            SetSpeed( DuckManager.main.terminalVelocity );

        }
    
    }

    public float GetSpeed(bool cached = false)
    {
        return (cached ? currentVelocity : cachedVelocity).magnitude;
    }

    private void SetSpeed(float newSpeed) {

        b.velocity = b.velocity.normalized * newSpeed;
    
    }  

    public bool IsSonic()
    {
        return GetSpeed(true) > DuckManager.main.sonicTreshold;
    }

    public void Reflect () {

        b.velocity = cachedVelocity / -4f;

    
    }

}
