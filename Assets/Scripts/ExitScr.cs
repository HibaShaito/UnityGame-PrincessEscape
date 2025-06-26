using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScr : MonoBehaviour
{
   
    public void ExitGame()
    {
        // Quit the application
        Application.Quit();
        
        // Log a message to the console to verify the method is called
        Debug.Log("Game is exiting...");

        // If running in the Unity editor, stop playing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}


