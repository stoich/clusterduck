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

    public static int currentDuckPrice = 0;

    private int[] duckInflation = new[] { 200, 500, 2000, 3000, 5000, 10000, 20000, 30000, 50000 };

    // Use this for initialization
    void Start()
    {
        currentDuckPrice = duckInflation[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowStore()
    {
        storePanel.SetActive(true);
        openStoreButton.SetActive(false);
    }

    public void HideStore()
    {
        storePanel.SetActive(false);
        openStoreButton.SetActive(true);
    }

    public void BuyDuck()
    {
        if (ScoreManager.main.mainScore > currentDuckPrice)
        {
            ScoreManager.main.AddPoints(-currentDuckPrice);

            var current = Array.IndexOf(duckInflation, currentDuckPrice);
            print(current);
            var newPriceIndex = current + 1;

            int newPrice;
            if (newPriceIndex < duckInflation.Length)
                newPrice = duckInflation[newPriceIndex];
            else
                newPrice = duckInflation[duckInflation.Length - 1];

            print(newPrice);
            currentDuckPrice = newPrice;

            createGenerator.CreateObstacle(true);
            HideStore();
        }
    }

    private void InflateDuckPrice()
    {

    }

}
