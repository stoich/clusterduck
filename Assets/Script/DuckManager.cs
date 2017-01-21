using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    public int startingDuckCount;
    public GameObject duckPrefab;
    public List<GameObject> duckList;
    public static DuckManager main;
    public float sonicTreshold = 2f;
    public float terminalVelocity = 20f;

    void Awake()
    {

        if (main != null)
        {
            Destroy(gameObject);
        }
        main = this;

    }

    void Start()
    {
        if (!IsOdd(startingDuckCount))
            throw new Exception("PLEASE USE ODD NUMBER OF STARTING DUCKS FOR NOW!");

        duckList = new List<GameObject>();
        PlaceInitially();

    }

    private void PlaceInitially()
    {
        var x = transform.position.x;
        var spacing = ScreenDimensions.Height / startingDuckCount;

        var startingPointInMiddle = new Vector2(x, 0);
        var offest = new Vector2(0, spacing);

        var currentDuckCount = startingDuckCount;

        AddDuck(startingPointInMiddle);
        currentDuckCount--;

        var incr = 1;

        while (currentDuckCount > 0)
        {

            AddDuck(startingPointInMiddle + offest * incr);
            AddDuck(startingPointInMiddle + offest * -incr);

            currentDuckCount -= 2;
            incr++;
        }
    }

    private static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }

    public void AddDuck(Vector2 position)
    {
        var d = (GameObject)Instantiate(duckPrefab, position, new Quaternion());
        d.transform.parent = transform;
        duckList.Add(d);
        d.name += duckList.IndexOf(d).ToString();
        d.GetComponent<ObstacleHandler>().managerReference = this;

        ScoreManager.main.UpdateDuckCount();
    }

    public void OnDuckDeath(GameObject duck)
    {
        duckList.Remove(duck);
        Destroy(duck);

        ScoreManager.main.LoseDuck();

        if (duckList.Count <= 0) {
            GameManager.main.TryGameOver();
        }
    }

    void OnDestroy()
    {
        if (main == this)
        {
            main = null;
        }
    }

}
