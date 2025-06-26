using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class Coins2 : MonoBehaviour 
{ 
    [SerializeField] GameObject Obj_prefab; 
    public float minCount = 100, maxCount = 200, currentCount = 0; 
    float lastAddedObj = 0; 
 
    void AddObj() 
    { 
        Vector3 randomPosition = new Vector3(Random.Range(-470f, -116f), 10f, Random.Range(-434.9299f, -393.2f)); // Start with a high y value 
        RaycastHit hit; 
 
        // Perform a raycast downwards to find the ground 
        if (Physics.Raycast(randomPosition, Vector3.down, out hit, Mathf.Infinity)) 
        { 
            randomPosition.y = hit.point.y + 1f; // Place the coin slightly above the ground 
        } 
        else 
        { 
            randomPosition.y = 5f; // Default y position if no ground is hit 
        } 
 
        GameObject objName = Instantiate(Obj_prefab); 
        objName.transform.position = randomPosition; 
        objName.transform.parent = transform; 
        currentCount++; 
    } 
 
    void Start() 
    { 
        if (currentCount <= 100) 
        { 
            for (int i = 0; i < 100; i++) 
            { 
                AddObj(); 
            } 
        } 
    } 
 
    void Update() 
    { 
        if (currentCount <= 100) 
        { 
            AddObj(); 
        } 
    } 
}