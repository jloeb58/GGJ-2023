using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to assist in calling ChangeTrack() from the AudioManager script when a trigger has been entered
public class SwitchMusicTrigger : MonoBehaviour
{
    // Public Variables
    public AudioClip newTrack;
    public AudioClip oldTrack;

    private AudioManager audioManager;
    private bool newTrackPlaying;

    // Start is called before the first frame update
    void Start()
    {
        // Automatically finds the AudioManager component in the scene
        audioManager = FindObjectOfType<AudioManager>();

        newTrackPlaying = false;
    }

    // OnTriggerEnter event to be called when a player walks into a collider 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {   
            if(newTrackPlaying == false)
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
        }
    }
}
