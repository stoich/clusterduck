using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public float cooldown_const;
    private float cooldown = 3;

    public float speedMax = 2;
    public float speedMin = 1;

    public GameObject obstacle;
    private float screenRangeMin;
    private float screenRangeMax;
    private Vector2 createProximityCheckySize = new Vector2(1.2f, 1.2f);


    // Use this for initialization
    void Start()
    {
        var screenHeight = 2f * Camera.main.orthographicSize;
        //screenWidth = screenHeight * Camera.main.aspect;

        // screenRangeMax = screenWidth / 2;
        // screenRangeMin = -screenWidth / 2;

        screenRangeMax = screenHeight / 2;
        screenRangeMin = -screenHeight / 2;

        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            CreateSphere();
            cooldown = cooldown_const;
        }

    }

    void CreateSphere()
    {
        var newSphere = (GameObject)Instantiate(obstacle, new Vector3(0, 0, -1000), new Quaternion());

        var randomSpeed = Random.Range(speedMin, speedMax);

        newSphere.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);

        var nonOverlappingPosition = GetNonOverlappingRandomPosition(screenRangeMin, screenRangeMax);

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
