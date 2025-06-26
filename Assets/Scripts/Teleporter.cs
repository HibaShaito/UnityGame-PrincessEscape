using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestination;
    public float offsetAboveGround = 0.5f; // Adjust this value as needed
    public GameObject loadingCanvas; // Assign your loading UI Canvas here
    public VideoPlayer videoPlayer; // Assign your VideoPlayer component here
    public float minCameraDistance = 2f; // Minimum distance for the camera to be from the character
    public float maxCameraDistance = 10f; // Maximum distance for the camera to be from the character

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the teleporter");
            CharacterController characterController = other.GetComponent<CharacterController>();
            if (characterController != null)
            {
                StartCoroutine(TeleportWithLoading(other.transform));
            }
            else
            {
                Debug.LogError("No CharacterController found on the player");
            }
        }
    }

    private IEnumerator TeleportWithLoading(Transform player)
    {
        // Show the loading UI and play the video
        loadingCanvas.SetActive(true);
        videoPlayer.Play();

        Debug.Log("Playing loading video");

        // Wait for a short moment to display the loading screen
        yield return new WaitForSeconds(0.5f);

        Vector3 targetPosition = teleportDestination.position;
        targetPosition.y += offsetAboveGround; // Ensure the character is above the ground

        // Disable the character controller to avoid conflicts during teleportation
        CharacterController characterController = player.GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = false;
        }

        // Perform a raycast downwards from the teleport destination
        RaycastHit hit;
        if (Physics.Raycast(targetPosition, Vector3.down, out hit))
        {
            // Adjust target position to be slightly above the hit point
            targetPosition.y = hit.point.y + offsetAboveGround;
            Debug.Log("Adjusted target position based on raycast hit");
        }

        // Set the player's position to the target position
        player.position = targetPosition;

        // Re-enable the character controller
        if (characterController != null)
        {
            characterController.enabled = true;
        }

        // Wait until the camera reaches the player
        yield return StartCoroutine(WaitForCameraToReachPlayer(player));

        // Hide the loading UI and stop the video
        videoPlayer.Stop();
        loadingCanvas.SetActive(false);
        Debug.Log("Teleported and finished loading");
    }

    private IEnumerator WaitForCameraToReachPlayer(Transform player)
    {
        Camera mainCamera = Camera.main;

        while (true)
        {
            float distance = Vector3.Distance(mainCamera.transform.position, player.position);
            Debug.Log($"Camera distance: {distance}");
            if (distance >= minCameraDistance && distance <= maxCameraDistance)
            {
                Debug.Log("Camera reached player");
                break;
            }
            yield return null;
        }
    }
}
