using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class collect1 : MonoBehaviour 
{ 
    private chestManager gameManager; 
 
    // Start is called before the first frame update 
    void Start() 
    { 
        // Find the GameManager in the scene 
        gameManager = GameObject.FindObjectOfType<chestManager>(); 
    } 
 
    // This function is called when another collider marked as a trigger touches this collider 
    private void OnTriggerEnter(Collider other) 
    { 
        // Check if the other object has the tag "Player" 
        if (other.CompareTag("Player")) 
        { 
            // Add 100 coins and 10 jewels via the GameManager 
            gameManager.AddCoins(100); 
            gameManager.AddJewels(10); 
            
            // Destroy the chest prefab 
            Destroy(gameObject); 
        } 
    } 
}
