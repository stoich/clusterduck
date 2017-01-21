using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualSpeedIndicator : MonoBehaviour
{
    private SpeedManager speedManager;
    private SpriteRenderer sp;
    private Color defaultColor;

    void Start()
    {
        speedManager = GetComponent<SpeedManager>();
        sp = GetComponent<SpriteRenderer>();
    }

    //TODO - this would work so much better with events...
    void Update()
    {
        if (speedManager.IsSonic())
            sp.color = Color.red;
        else
            sp.color = Color.white;
    }
}
