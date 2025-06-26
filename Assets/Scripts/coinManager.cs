using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 
 
public class coinManager : MonoBehaviour 
{ 
    public Text moneyText; 
    private int money=0; 
     private int moneyCount; 
 
    void Start() 
    { 
         // Parse the initial moneyText value to moneyCount
        if (int.TryParse(moneyText.text, out money))
        {
            moneyCount=money;
        }
        else
        {
          
        }
        // Initialize the money count 
        UpdateMoneyText(); 
    } 
    void Update(){
        
         // Parse the initial moneyText value to moneyCount
        if (int.TryParse(moneyText.text, out money))
        {
            moneyCount=money;
        }
        else
        {
          
        }
        // Initialize the money count 
        UpdateMoneyText(); 
    }
 
    // Method to increment the money count and update the UI 
    public void AddMoney(int amount) 
    { 
        moneyCount += amount; 
        UpdateMoneyText(); 
    } 
 
    // Method to update the money text UI 
    private void UpdateMoneyText() 
    { 
        moneyText.text = moneyCount.ToString(); 
    } 
}