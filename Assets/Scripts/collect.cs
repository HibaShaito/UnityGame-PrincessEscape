using System.Collections; 
using UnityEngine; 
 
public class collect : MonoBehaviour 
{ 
    private coinManager gameManager; 
    public AudioSource collectSound; // Assign this in the inspector or dynamically 
 
    // Start is called before the first frame update 
    void Start() 
    { 
        // Find the GameManager in the scene 
        gameManager = GameObject.FindObjectOfType<coinManager>(); 
 
        // Ensure collectSound is attached to the coin prefab 
        collectSound = GetComponent<AudioSource>(); 
    } 
 
    // This function is called when another collider marked as a trigger touches this collider 
    private void OnTriggerEnter(Collider other) 
    { 
        // Check if the other object has the tag "Player" 
        if (other.CompareTag("Player")) 
        { 
            // Add money via the GameManager 
            gameManager.AddMoney(1); 
             
            // Play the collection sound 
            if (collectSound != null) 
            { 
                collectSound.Play(); 
            } 
 
            // Start the coroutine to raise the coin and destroy it after a delay 
            StartCoroutine(RaiseAndDestroyCoin()); 
        } 
    } 
 
    private IEnumerator RaiseAndDestroyCoin() 
    { 
        float duration = 0.5f; // Further reduced duration to raise the coin even faster 
        float elapsed = 0f; 
        Vector3 startPosition = transform.position; 
        Vector3 endPosition = startPosition + Vector3.up * 3; // Raise the coin by 3 units 
 
        while (elapsed < duration) 
        { 
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsed / duration); 
            elapsed += Time.deltaTime; 
            yield return null; 
        } 
 
        // Ensure the coin reaches the final position before destruction 
        transform.position = endPosition; 
 
        // Wait for the sound to finish playing 
        if (collectSound != null) 
        { 
            while (collectSound.isPlaying) 
            { 
                yield return null; 
            } 
        } 
 
        // Destroy the coin prefab 
        Destroy(gameObject); 
    } 
}