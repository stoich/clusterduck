using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public float cooldown_const;
    private float cooldown = 3;

    public float speedMax = 2;
    public float speedMin = 1;

    public GameObject obstacle, duckCrate;
    private Vector2 createProximityCheckySize = new Vector2(1.2f, 1.2f);

    [Range(0f, 1f)]
    public float duckCrateChance = 0.05f;

    // Use this for initialization
    void Start()
    {
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            CreateObstacle();
            cooldown = cooldown_const;
        }

    }

    void CreateObstacle()
    {

        GameObject obstacleType = (Random.Range(0f, 1f) > duckCrateChance) ? obstacle : duckCrate;

        var newSphere = (GameObject)Instantiate(obstacleType, new Vector3(0, 0, -1000), new Quaternion());

        var randomSpeed = Random.Range(speedMin, speedMax);

        newSphere.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);

        var nonOverlappingPosition = GetNonOverlappingRandomPosition(ScreenDimensions.LowerEdgeFromCenter, ScreenDimensions.UpperEdgeFromCenter);

        if (nonOverlappingPosition != null)
        {
            newSphere.transform.position = (Vector3)nonOverlappingPosition;
        }
        else
            Destroy(newSphere);
    }

    private Vector3? GetNonOverlappingRandomPosition(float screenRangeMin, float screenRangeMax)
    {
        int attempts = 10;
        Vector3? generationPoint = null;

        while (attempts > 1)
        {
            var randomY = Random.Range(screenRangeMin, screenRangeMax);

            var testPoint = new Vector3(transform.position.x, randomY, 0);

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
