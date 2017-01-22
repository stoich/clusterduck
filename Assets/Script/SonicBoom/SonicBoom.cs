using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicBoom : MonoBehaviour
{
    public AudioClip boomSound;

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
        try
        {
            var audioManager = GameObject.Find("SoundManager").GetComponent<AudioSource>();
            audioManager.PlayOneShot(boomSound, 0.7f);
        }
        catch (Exception e)
        {
            print("COULD NOT PLAY BOOM SOUND!!!! Check references...");
        }

        foreach (var p in GetComponent<SonicBoomHelper>().duckList)
        {
            var boomDirection = p.transform.position - transform.position;
            p.GetComponent<Rigidbody2D>().AddForce(boomDirection.normalized * DuckManager.main.terminalVelocity, ForceMode2D.Impulse);
            p.GetComponent<SpeedManager>().SetOnFire(true);
        }
    }
}
