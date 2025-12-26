using UnityEngine;

public class carSound: MonoBehaviour
{
    public AudioSource engineIdleSound;
    public AudioSource engineRevSound; // Optional, for higher RPMs or specific revving sounds
    public float minRPM = 0f;
    public float maxRPM = 6000f;
    public float currentRPM = 0f; // This would be driven by your car physics
    public float idlePitch = 1.0f;
    public float maxRevPitch = 2.0f; // Maximum pitch for engineRevSound
    public float idleVolume = 0.5f;
    public float maxRevVolume = 1.0f; // Maximum volume for engineRevSound

    void Start()
    {
        // Ensure sounds are assigned and configured
        if (engineIdleSound == null)
        {
            Debug.LogError("Engine Idle Sound AudioSource not assigned!");
            enabled = false; // Disable script if essential component is missing
            return;
        }
        if (engineRevSound != null)
        {
            engineRevSound.Stop(); // Start with rev sound off
        }

        engineIdleSound.loop = true;
        engineIdleSound.Play();
    }

    void Update()
    {
        // Simulate RPM for demonstration, replace with actual car physics RPM
        // For example: currentRPM = myCarController.GetEngineRPM();
        if (ControlFreak2.CF2Input.GetKey(KeyCode.W)) // Simulate acceleration
        {
            currentRPM = Mathf.Min(currentRPM + Time.deltaTime * 500, maxRPM);
        }
        else
        {
            currentRPM = Mathf.Max(currentRPM - Time.deltaTime * 500, minRPM);
        }

        // Calculate a normalized RPM value (0 to 1)
        float normalizedRPM = Mathf.InverseLerp(minRPM, maxRPM, currentRPM);

        // Adjust pitch and volume of idle sound
        engineIdleSound.pitch = Mathf.Lerp(idlePitch, maxRevPitch, normalizedRPM);
        engineIdleSound.volume = Mathf.Lerp(idleVolume, maxRevVolume, normalizedRPM);

        // Optionally, use a separate sound for high RPMs
        if (engineRevSound != null)
        {
            if (currentRPM > (maxRPM * 0.5f) && !engineRevSound.isPlaying)
            {
                engineRevSound.loop = true;
                engineRevSound.Play();
            }
            else if (currentRPM <= (maxRPM * 0.5f) && engineRevSound.isPlaying)
            {
                engineRevSound.Stop();
            }
            // Adjust rev sound properties as well if it's playing
            if (engineRevSound.isPlaying)
            {
                engineRevSound.pitch = Mathf.Lerp(1.0f, maxRevPitch, (currentRPM - (maxRPM * 0.5f)) / (maxRPM * 0.5f));
                engineRevSound.volume = Mathf.Lerp(0.5f, maxRevVolume, (currentRPM - (maxRPM * 0.5f)) / (maxRPM * 0.5f));
            }
        }
    }
}