using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDimensions : MonoBehaviour
{

    private static float HalfSize
    {
        get
        {
            var screenHeight = 2f * Camera.main.orthographicSize;
            return screenHeight / 2;
        }
    }

    public static float LowerEdgeFromCenter
    {
        get
        {
            return -HalfSize;
        }
    }

    public static float UpperEdgeFromCenter
    {
        get
        {
            return HalfSize;
        }
    }
}
