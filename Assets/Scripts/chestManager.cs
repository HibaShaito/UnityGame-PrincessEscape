using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chestManager : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private Text jewelText;
    private int coin = 0;
    private int jewel = 0;
    private int coinCount;
    private int jewelCount;

    void Start()
    {
        // Parse the initial moneyText value to moneyCount
        if (int.TryParse(coinText.text, out coin))
        {
           coinCount=coin;
        }
        else
        {
            Debug.LogError("Failed to parse initial money count.");
        }
         // Parse the initial moneyText value to moneyCount
        if (int.TryParse(jewelText.text, out jewel))
        {
           jewelCount=jewel;
        }
        else
        {
            Debug.LogError("Failed to parse initial money count.");
        }
        // Initialize the counts and update the UI
        UpdateCoinText();
        UpdateJewelText();
    }
    void Update(){
        // Parse the initial moneyText value to moneyCount
        if (int.TryParse(coinText.text, out coin))
        {
           coinCount=coin;
        }
        else
        {
            Debug.LogError("Failed to parse initial money count.");
        }
         // Parse the initial moneyText value to moneyCount
        if (int.TryParse(jewelText.text, out jewel))
        {
           jewelCount=jewel;
        }
        else
        {
            Debug.LogError("Failed to parse initial money count.");
        }
        // Initialize the counts and update the UI
        UpdateCoinText();
        UpdateJewelText();
    }

    // Method to add coins
    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinText();
        Debug.Log("Coins: " + coinCount);
        CheckIfCollectedAll();
    }

    // Method to add jewels
    public void AddJewels(int amount)
    {
        jewelCount += amount;
        UpdateJewelText();
        Debug.Log("Jewels: " + jewelCount);
        CheckIfCollectedAll();
    }

    // Method to check if all items are collected
    private void CheckIfCollectedAll()
    {
        if (coinCount >= 100 && jewelCount >= 10)
        {
            Debug.Log("Collected all required coins and jewels!");
            // Add any additional logic here, such as triggering an event or advancing to the next level
        }
    }

    // Method to update the coin text UI
    private void UpdateCoinText()
    {
        coinText.text = coinCount.ToString();
    }

    // Method to update the jewel text UI
    private void UpdateJewelText()
    {
        jewelText.text = jewelCount.ToString();
    }
}
