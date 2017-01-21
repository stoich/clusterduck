using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;  

public class SonicBoomHelper : MonoBehaviour
{
    public float proximityTreshold;
    public SonicBoom sonicBoom;
    public VisualSonicBoomCue visualBoom;

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

        currentCentroid = SonicBoomHelper.FindCentroid(DuckPoints);
        transform.position = CurrentCentroid;

        if (IsBoomProximity(DuckPoints))
            visualBoom.Show();
        else
            visualBoom.Hide();
    }

    public static Vector2[] DuckPoints
    {
        get
        {
            return DuckManager.main.duckList.Select(d => (Vector2)d.transform.position).ToArray();
        }
    }

    private static Vector2 FindCentroid(Vector2[] points)
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
}
