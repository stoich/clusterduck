using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDimensions : MonoBehaviour
{

    public static float HeightHalf
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
            return -HeightHalf;
        }
    }

    public static float UpperEdgeFromCenter
    {
        get
        {
            return HeightHalf;
        }
    }

    public static float Height
    {
        get
        {
            return HeightHalf * 2;
        }
    }
}
