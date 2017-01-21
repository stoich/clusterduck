using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VisualSonicBoomCue : MonoBehaviour
{
    public SonicBoom sonicBoom;
    private SpriteRenderer icon;
    private bool readyToBoom = false;
    private string sonicBoomObjectName = "Sonic Boom";

    // Use this for initialization
    void Start()
    {
        icon = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseTarget, Vector2.zero, 500);
        }
    }

    void OnMouseDown()
    {
        print("click");
        if (readyToBoom)
            sonicBoom.Blow();
    }

    internal void Show()
    {
        icon.enabled = true;
        readyToBoom = true;
    }

    internal void Hide()
    {
        icon.enabled = false;
        readyToBoom = false;
    }
}
