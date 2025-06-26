using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material daySkybox; // Assign the day skybox material in the inspector
    public Material nightSkybox; // Assign the night skybox material in the inspector
    public Material transitionSkybox; // Assign the transition skybox material in the inspector
    public Light directionalLight; // Assign the directional light in the inspector

    private float changeInterval = 60f; // 60 seconds for the full cycle
    private float transitionDuration = 30f; // Duration of the transition in seconds
    private float timer;
    private bool isDay = true;
    private bool isTransitioning = false;
    private float transitionTimer;

    void Start()
    {
        // Set the initial skybox and light
        RenderSettings.skybox = daySkybox;
        directionalLight.enabled = true;
        timer = changeInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !isTransitioning)
        {
            // Start the transition
            isTransitioning = true;
            transitionTimer = 0;
        }

        if (isTransitioning)
        {
            transitionTimer += Time.deltaTime;
            float t = transitionTimer / transitionDuration;

            if (isDay)
            {
                RenderSettings.skybox.Lerp(daySkybox, nightSkybox, t);
            }
            else
            {
                RenderSettings.skybox.Lerp(nightSkybox, daySkybox, t);
            }

            if (transitionTimer >= transitionDuration)
            {
                // End the transition
                isTransitioning = false;
                timer = changeInterval;
                isDay = !isDay;
                RenderSettings.skybox = isDay ? daySkybox : nightSkybox;

                // Toggle light
                directionalLight.enabled = isDay;
            }
        }
    }
}
