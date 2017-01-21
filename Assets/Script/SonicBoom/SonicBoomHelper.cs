using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class SonicBoomHelper : MonoBehaviour
{
    public static float proximityTreshold = 3;
    public SonicBoom sonicBoom;
    public VisualSonicBoomCue visualBoom;

    private List<GameObject> dl = new List<GameObject>();
    public List<GameObject> duckList
    {
        get
        {
            var l = new List<GameObject>();
            foreach (var d in dl)
            {
                if (d != null)
                    l.Add(d);
            }

            return l;
        }
        set
        {
            dl = value;
        }
    }


    public bool IsBoomProximity(Vector2[] points)
    {
        foreach (var p in points)
        {
            if (Vector2.Distance(CurrentCentroid, p) > proximityTreshold)
                return false;
        }

        return true;
    }

    private void Update()
    {

        if (duckList.Count < 1)
        {
            FindSonicGroup.boomsList.Remove(gameObject);
            Destroy(gameObject);
            return;
        }

        currentCentroid = SonicBoomHelper.FindCentroid(DuckPoints);
        transform.position = currentCentroid;

        if (IsBoomProximity(DuckPoints))
            visualBoom.Show();
        else
        {
            visualBoom.Hide();
            FindSonicGroup.boomsList.Remove(gameObject);
            Destroy(gameObject);
        }

    }

    public Vector2[] DuckPoints
    {
        get
        {
            var l = new List<GameObject>();
            foreach (var d in duckList)
            {
                if (d != null)
                    l.Add(d);
            }

            if (duckList == null || duckList.Count < 1)
                throw new Exception("WTF duck!!!!");


            return l.Select(d => (Vector2)d.transform.position).ToArray();
        }
    }

    public static Vector2 FindCentroid(Vector2[] points)
    {
        float sumOfX = 0;
        float sumOfY = 0;

        foreach (var p in points)
        {
            sumOfX += p.x;
            sumOfY += p.y;
        }

        var c = points.Length;
        return new Vector2(sumOfX / c, sumOfY / c);
    }

    private Vector2 currentCentroid;
    public Vector2 CurrentCentroid
    {
        get
        {
            return currentCentroid;
        }

        set
        {
            currentCentroid = value;
        }
    }

    // private void RemoveDeadDucksFromList()
    // {
    //  
    // }

}
