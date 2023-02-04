using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to help with audio track changes
public class AudioManager : MonoBehaviour
{
    // Public Variables
    public AudioSource musicSource;

    // Private Variables
    private float musicCurrentTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Changes track based on the current time of the current track, it will begin playing the new track at that specified time for a smoother transition
    public void ChangeTrack(AudioClip track)
    {
        musicCurrentTime = musicSource.time;
        musicSource.Stop();

        musicSource.clip = track;
        musicSource.time = musicCurrentTime;
        musicSource.Play();
    }
}
