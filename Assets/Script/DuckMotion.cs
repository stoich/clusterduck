using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMotion : MonoBehaviour
{

    public Rigidbody2D bodyWithSpeed;
    public GameObject objToRotate;
    float lowerLimit = 6f, upperLimit = 30f, maxRotation = 30f;

    void Update()
    {
        float rotation = bodyWithSpeed.velocity.magnitude;

        //print(rotation);

        rotation -= lowerLimit;
        rotation /= (upperLimit - lowerLimit);
        rotation = Mathf.Clamp(rotation, 0f, 1f);
        rotation = Mathf.Pow(rotation, 0.5f);
        rotation *= maxRotation;

        objToRotate.transform.localEulerAngles = new Vector3(0f, 0f, rotation);
    }
}
