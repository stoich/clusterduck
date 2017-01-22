using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject openStoreButton;
    public GameObject storePanel;
    public ObstacleGenerator createGenerator;
 
    public Animator storeAnimator;
    bool open;

    public static int currentDuckPrice = 0;
    int level = 0;

    private int[] duckInflation = new[] { 200, 500, 2000, 3000, 5000, 10000, 20000, 30000, 50000 };

    // Use this for initialization
    void Start()
    {
        currentDuckPrice = DuckInflation(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    int DuckInflation(int level) {
        int magnitude = Mathf.FloorToInt(level / 3 + 0.1f);
        int multiplier = 1;
        switch(level - magnitude * 3) {
            case 1: multiplier = 2; break;
            case 2: multiplier = 5; break;
        }
        return Mathf.RoundToInt(Mathf.Pow(10f, magnitude + 2) * multiplier);
    }

    public void ShowStore()
    {
        if (!open);
        storeAnimator.SetBool("open", open = true);
    }

    public void HideStore()
    {
        if (open)
        storeAnimator.SetBool("open", open = false);
    }

    public void BuyDuck()
    {
        if (ScoreManager.main.mainScore >= currentDuckPrice)
        {
            ScoreManager.main.AddPoints(-currentDuckPrice);

            level++;

            int newPrice = DuckInflation(level);
            currentDuckPrice = newPrice;

            createGenerator.CreateObstacle(true);
            HideStore();
        }
        else
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }

    private void InflateDuckPrice()
    {

    }

}
