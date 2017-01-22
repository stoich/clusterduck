using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    // public float thresholdSpeed;
    private Rigidbody2D body;
    private SpeedManager speedManager;
    public DuckManager managerReference;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speedManager = GetComponent<SpeedManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Obstacle")
        {

            Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();

            if (speedManager.IsSonic())
            {
                if (obstacle != null)
                    obstacle.OnBreak(speedManager.GetSpeed());

                ScoreManager.main.AddPoints(100);
                Destroy(collision.gameObject);

                speedManager.Reflect(collision.gameObject.transform.position);
            }

        }
    }
}
