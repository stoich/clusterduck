using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class SoundManager : MonoBehaviour
{
    public static SoundManager main;
    public AudioClip[] gamesounds;

    public AudioSource crateAudio;

    void Awake()
    {

        if (main != null)
        {
            Destroy(gameObject);
        }
        main = this;

    }

    void OnDestroy()
    {

        if (main == this)
        {
            main = null;
        }

    }

    public void SmashCrate()
    {

        crateAudio.pitch = Random.Range(0.8f, 1.2f);
        crateAudio.Play();
    }

    public static void PlaySound(int index)
    {
        var o = GameObject.Find("SoundManager");
        var m = o.GetComponent<SoundManager>();
        var a = o.GetComponent<AudioSource>();
        a.PlayOneShot(m.gamesounds[index]);
    }

}