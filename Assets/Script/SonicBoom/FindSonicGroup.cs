using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSonicGroup : MonoBehaviour
{
    public GameObject boomPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            //  print("closes duck is to " + gameObject.name + " is " + GetClosestDuck().name);


            var closest = GetClosestDuck();
            var closePos = (Vector2)closest.transform.position;
            var thisDuckPos = (Vector2)gameObject.transform.position;

            if (Vector2.Distance(closePos, thisDuckPos) < SonicBoomHelper.proximityTreshold)
            {
                print("Treshold proximity!");

                var midPoint = SonicBoomHelper.FindCentroid(new[] { closePos, thisDuckPos });
                var inRangeList = FindDucksInRange(midPoint, SonicBoomHelper.proximityTreshold);

                if (inRangeList.Count > 2)
                {

                    print("-------group:------------");
                    foreach (var d in inRangeList)
                    {
                        print(d.name);
                    }
                    print("---END group:------------");

                    var boom = Instantiate(boomPrefab, midPoint, new Quaternion());

                }


            }
        }
    }

    private GameObject GetClosestDuck()
    {
        var currentDuck = gameObject;
        List<GameObject> listWithoutMyDUck = new List<GameObject>(DuckManager.main.duckList);

        if (!listWithoutMyDUck.Remove(currentDuck))
            throw new System.Exception("WTF; current Duck not in list!??!?");

        var closestDuck = listWithoutMyDUck[0];
        listWithoutMyDUck.Remove(closestDuck);

        foreach (GameObject d in listWithoutMyDUck)
        {
            var distOld = Vector2.Distance(currentDuck.transform.position, closestDuck.transform.position);
            var distNew = Vector2.Distance(currentDuck.transform.position, d.transform.position);
            if (distNew < distOld)
                closestDuck = d;
        }

        return closestDuck;
    }

    private List<GameObject> FindDucksInRange(Vector2 reference, float range)
    {
        List<GameObject> list = new List<GameObject>();
        foreach (var d in DuckManager.main.duckList)
        {
            var pos = d.transform.position;
            if (Vector2.Distance(reference, pos) < range)
                list.Add(d);
        }

        return list;
    }
}
