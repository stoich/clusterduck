using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    Rigidbody2D body;
    public float speed = 5f;
    private bool swipingCurrentDuck = false;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //If this is not the duck you clicked on - ignore the swipe...
        if (Input.GetMouseButtonDown(0))
        {
            if (IsClickOnCurrentDuck())
                swipingCurrentDuck = true;
        }

        if (swipingCurrentDuck)
            Swipe();

        if (currentSwipe != Vector2.zero)
        {
            body.velocity = Vector2.zero;
            body.AddForce(currentSwipe * speed, ForceMode2D.Impulse);
            currentSwipe = Vector2.zero;
            swipingCurrentDuck = false;
        }

    }

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe = Vector2.zero;

    public Vector2 Swipe()
    {

        if (Input.GetMouseButtonDown(0))
        {
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
        }

        return currentSwipe;
    }

    private bool IsClickOnCurrentDuck()
    {
        var mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseTarget, Vector2.zero, 500);
        if (hit)
            return hit.transform.gameObject == gameObject;
        else
            return false;
    }
}
