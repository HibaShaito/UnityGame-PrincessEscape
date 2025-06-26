using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    public GameObject mapPanel; // The panel containing the map UI
    public Transform[] waypoints; // Array of waypoints in the game
    public GameObject player; // The player character
    public ParticleSystem teleportEffect; // Optional teleport effect

    void Start()
    {
        mapPanel.SetActive(false); // Hide the map UI initially
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMap();
        }
    }

    public void ToggleMap()
    {
        mapPanel.SetActive(!mapPanel.activeSelf);
    }

    public void TeleportToWaypoint(int index)
    {
        if (index >= 0 && index < waypoints.Length)
        {
            if (teleportEffect != null)
            {
                Instantiate(teleportEffect, player.transform.position, Quaternion.identity);
            }
            player.transform.position = waypoints[index].position;
            if (teleportEffect != null)
            {
                Instantiate(teleportEffect, waypoints[index].position, Quaternion.identity);
            }
            player.transform.rotation = waypoints[index].rotation;
            ToggleMap(); // Hide the map after teleporting
        }
    }
}
