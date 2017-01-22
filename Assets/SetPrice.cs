using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class SetPrice : MonoBehaviour
{
    Text t;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Regex rgx = new Regex("[0-9]{2,}");
        string result = rgx.Replace(t.text, Store.currentDuckPrice.ToString());
        t.text = result;
    }

}
