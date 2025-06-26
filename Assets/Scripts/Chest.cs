using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject objPrefab;
    public float minCount = 100, maxCount = 200, currentCount = 0;
    public float minDistance = 5f; // Minimum distance between objects
    private List<Vector3> positions = new List<Vector3>(); // List to store positions of placed objects
    private Terrain terrain;
    private float chestOffset = 1f; // Offset to place the chest above the terrain

    void Start()
    {
        // Get the terrain component
        terrain = Terrain.activeTerrain;

        // Add initial objects
        for (int i = 0; i < minCount; i++)
        {
            AddObj();
        }
    }

    void AddObj()
    {
        Vector3 randomPosition;
        bool positionValid;

        do
        {
            positionValid = true;

            // Generate random position within the terrain boundaries
            float terrainX = Random.Range(terrain.transform.position.x, terrain.transform.position.x + terrain.terrainData.size.x);
            float terrainZ = Random.Range(terrain.transform.position.z, terrain.transform.position.z + terrain.terrainData.size.z);

            randomPosition = new Vector3(terrainX, 0, terrainZ);

            // Sample the terrain height at the random position
            float terrainY = terrain.SampleHeight(randomPosition) + terrain.transform.position.y;

            // Set the y-coordinate slightly above the terrain surface
            randomPosition.y = terrainY + chestOffset;

            // Check if the new position is too close to any of the previous positions
            foreach (Vector3 pos in positions)
            {
                if (Vector3.Distance(randomPosition, pos) < minDistance)
                {
                    positionValid = false;
                    break;
                }
            }
        } while (!positionValid);

        // Store the new position
        positions.Add(randomPosition);

        // Instantiate the object
        GameObject obj = Instantiate(objPrefab);
        obj.transform.position = randomPosition;
        obj.transform.parent = transform;
        currentCount++;
    }

    void Update()
    {
        // Optionally remove this check if you want to control the number of objects differently
        if (currentCount < minCount)
        {
            AddObj();
        }
    }
}
