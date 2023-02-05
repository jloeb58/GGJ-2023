using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SwitchMusicTriggerSunlight : MonoBehaviour
{
    // Public Variables
    public AudioClip newTrack;
    public AudioClip oldTrack;

    // Particle systems will be modified based on objective progress
    public GameObject rainParticleSystem;
    public GameObject sunlightParticleSystem;

    // Audio Source that plays the rain sound effect
    public AudioSource rainAudioSource;

    // Volume object that we will access the fog effects
    public Volume fogVolume;

    // Private volume profile objects to access volume profiles (fog, skybox)
    private VolumeProfile profile;
    private Fog fogComponent;

    private AudioManager audioManager;
    private bool newTrackPlaying;
    private bool changeWeather;

    // Start is called before the first frame update
    void Start()
    {
        // Automatically finds the AudioManager component in the scene
        audioManager = FindObjectOfType<AudioManager>();

        newTrackPlaying = false;
        changeWeather = false;

        // Set particle systems accordingly
        sunlightParticleSystem.SetActive(false);

        // Activate volume fog
        profile = fogVolume.sharedProfile;
        if (profile.TryGet<Fog>(out var fog))
        {
            fogComponent = fog;
            fogComponent.enabled.overrideState = true;
        }
    }

    // OnTriggerEnter event to be called when a player walks into a collider 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (newTrackPlaying == false)
            {
                audioManager.ChangeTrack(newTrack);
                Debug.Log("Playing track: " + newTrack.name);
                newTrackPlaying = true;
            }
            else
            {
                audioManager.ChangeTrack(oldTrack);
                Debug.Log("Playing track: " + oldTrack.name);
                newTrackPlaying = false;
            }

            if (changeWeather == false)
            {
                changeWeather = true; 

                // Deactivate rain and activate ending sunlight
                rainParticleSystem.GetComponent<ParticleSystem>().Stop();
                sunlightParticleSystem.SetActive(true);

                // Deactivate volume fog
                profile = fogVolume.sharedProfile;
                if (profile.TryGet<Fog>(out var fog))
                {
                    fogComponent = fog;
                    fogComponent.enabled.overrideState = false;
                }

                // Fade out rain audio source
                StartCoroutine(FadeAudioSource.StartFade(rainAudioSource, 3f, 0f));
            }
        }
    }
}
