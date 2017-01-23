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
    public float sonicTreshold = 0.7f;
    public float terminalVelocity = 20f;

    void Awake()
    {

        if (main != null)
        {
            Destroy(gameObject);
        }
        main = this;

    }

    public void PlaceDucks()
    {
        duckList = new List<GameObject>();
        PlaceInitially();

    }

    private void PlaceInitially()
    {
        var x = transform.position.x;
        var spacing = ScreenDimensions.Height / (startingDuckCount + 1);

        var startingPointInMiddle = new Vector2(x, ScreenDimensions.Height / -2f);
        var offest = new Vector2(0, spacing);

        for (int i = 0; i < startingDuckCount; i++) {

            AddDuck(startingPointInMiddle + offest * (i + 1));
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

        DuckSpriteManager.main.SetSpecialChance(duckList.Count);


    }

    public void OnDuckDeath(GameObject duck)
    {
        duckList.Remove(duck);
        Destroy(duck);

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
