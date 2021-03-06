﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public static ObstacleGenerator main;

    public float cooldown_const;
    private float scaled_cooldown;
    private float cooldown = 3;

    public float speedMax = 2;
    public float speedMin = 1;

    public GameObject obstacle, duckCrate;
    private Vector2 createProximityCheckySize = new Vector2(1.2f, 1.2f);

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
    // Use this for initialization
    void Start()
    {
        cooldown = 0;
        ScaleCooldown(1);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            CreateObstacle();
            cooldown = scaled_cooldown * Random.Range(0.75f, 1.33f);
        }

    }

    public void ScaleCooldown(int ducks)
    {
        scaled_cooldown = cooldown_const / (1 + ducks * 0.25f);
    }

    public void CreateObstacle(bool isDuckCrate = false)
    {
        SoundManager.PlaySound(1);

        GameObject obstacleType = (isDuckCrate) ? duckCrate : obstacle;

        var newSphere = (GameObject)Instantiate(obstacleType, new Vector3(0, 0, -1000), new Quaternion());

        var randomSpeed = Random.Range(speedMin, speedMax);

        Vector2 travelVector = Vector2.left.Rotate(Random.Range(0f, 1f));
        travelVector *= randomSpeed;

        newSphere.GetComponent<Rigidbody2D>().AddForce(travelVector, ForceMode2D.Impulse);

        var nonOverlappingPosition = GetNonOverlappingRandomPosition();

        if (nonOverlappingPosition != null)
        {
            newSphere.transform.position = (Vector3)nonOverlappingPosition;
        }
        else
            Destroy(newSphere);
    }

    private Vector3? GetNonOverlappingRandomPosition()
    {
        float screenRangeMinX = -Level.screenSizeX; //Fix
        float screenRangeMaxX = Level.screenSizeX; //Fix
        float screenRangeMinY = ScreenDimensions.LowerEdgeFromCenter;
        float screenRangeMaxY = ScreenDimensions.UpperEdgeFromCenter;

        int attempts = 10;
        Vector3? generationPoint = null;

        while (attempts > 1)
        {
            var randomX = Random.Range(screenRangeMinX, screenRangeMaxX);
            var randomY = Random.Range(screenRangeMinY, screenRangeMaxY);

            var testPoint = new Vector3(randomX, randomY, 0);

            Collider2D colls = Physics2D.OverlapBox(testPoint, new Vector2(1.2f, 1.2f), 0, LayerMask.GetMask("Obstacle"));

            if (colls == null)
            {
                generationPoint = testPoint;
            }

            attempts--;
        }
        return generationPoint;
    }

}
