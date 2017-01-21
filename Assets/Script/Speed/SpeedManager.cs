using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    private Rigidbody2D b;
    public float sonicTreshold;

    // Use this for initialization
    void Start()
    {
        b = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private float CurrentSpeed()
    {
        return b.velocity.magnitude;
    }

    public bool IsSonic()
    {
        return CurrentSpeed() > sonicTreshold;
    }
}
