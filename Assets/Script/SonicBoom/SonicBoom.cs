﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicBoom : MonoBehaviour
{


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
        foreach (var p in GetComponent<SonicBoomHelper>().duckList)
        {
            var boomDirection = p.transform.position - transform.position;
            p.GetComponent<Rigidbody2D>().AddForce(boomDirection.normalized * DuckManager.main.terminalVelocity, ForceMode2D.Impulse);
        }
    }
}
