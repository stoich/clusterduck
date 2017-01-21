using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public static class Vector3Extension {
     
     public static Vector2 Vec2(this Vector3 v) {
         return new Vector2(v.x,v.y);
     }

     public static Vector2 Rotate(this Vector2 v, float realdian) {
         float sin = Mathf.Sin(realdian * 2f * Mathf.PI);
         float cos = Mathf.Cos(realdian * 2f * Mathf.PI);
         
         float tx = v.x;
         float ty = v.y;
         v.x = (cos * tx) - (sin * ty);
         v.y = (sin * tx) + (cos * ty);
         return v;
     }
}