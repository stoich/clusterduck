using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    Rigidbody2D body;
    public float speed = 5f;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();

        if (currentSwipe != Vector2.zero)
        {
            body.velocity = Vector2.zero;
            body.AddForce(currentSwipe * speed, ForceMode2D.Impulse);
            currentSwipe = Vector2.zero;
        }

    }

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe = Vector2.zero;

    public Vector2 Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe = currentSwipe / 50;

            //    //swipe upwards
            //    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            //    {
            //        Debug.Log("up swipe");
            //    }
            //    //swipe down
            //    if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            //    {
            //        Debug.Log("down swipe");
            //    }
            //    //swipe left
            //    if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            //    {
            //        Debug.Log("left swipe");
            //    }
            //    //swipe right
            //    if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            //    {
            //        Debug.Log("right swipe");
            //    }
        }

        return currentSwipe;
    }
}
