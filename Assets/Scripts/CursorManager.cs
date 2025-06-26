using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.LeftAlt; // The key to toggle cursor visibility
    private bool cursorVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            cursorVisible = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyUp(toggleKey))
        {
            cursorVisible = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
