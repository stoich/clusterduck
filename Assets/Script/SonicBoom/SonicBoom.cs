using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicBoom : MonoBehaviour
{

    public float boomForce = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Blow()
    {
        foreach (var p in DuckManager.main.duckList)
        {
            var boomDirection = p.transform.position - transform.position;
            p.GetComponent<Rigidbody2D>().AddForce(boomDirection.normalized * boomForce, ForceMode2D.Impulse);
        }
    }
}
