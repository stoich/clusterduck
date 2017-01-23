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
        currentDuckPrice = DuckInflation(DuckManager.main.startingDuckCount - 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    int DuckInflation(int level) {
        int magnitude = Mathf.FloorToInt(level / 4 + 0.1f);
        float multiplier = 1;
        switch(level - magnitude * 4) {
            case 1: multiplier = 2f; break;
            case 2: multiplier = 3.5f; break;
            case 3: multiplier = 6f; break;
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
