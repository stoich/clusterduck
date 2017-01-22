using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    private Rigidbody2D b;
    public Vector3 cachedVelocity, currentVelocity;

    public float normalDrag = 1f, fireDrag = 0.5f;

    bool onFire;


    void Start()
    {
        b = GetComponent<Rigidbody2D>();
        SetOnFire(false);
    }

    void FixedUpdate()
    {
        cachedVelocity = currentVelocity;
        currentVelocity = b.velocity;

        if (onFire && !IsSonic()) {
            SetOnFire(false);
        }

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
        return GetSpeed(false) > DuckManager.main.sonicTreshold;
    }

    public void SetOnFire(bool fire) {

        if (fire) {
            onFire = true;
            b.drag = fireDrag;
        } else {
            onFire = false;
            b.drag = normalDrag;
        }
    }

    public void Reflect (Vector3 other) {

        b.velocity = (other - transform.position).normalized * (cachedVelocity.magnitude  / (onFire ? 1f : -1f));
    
    }

}
