using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public static class Vector3Extension {
     
     public static Vector2 Vec2(this Vector3 v) {
         return new Vector2(v.x,v.y);
     }
}