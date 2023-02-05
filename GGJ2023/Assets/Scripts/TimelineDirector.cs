using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class TimelineDirector : MonoBehaviour
{
    public static TimelineDirector TD; 
    public PlayableDirector PD;
    public TimelineAsset TL;
    // Start is called before the first frame update

    private void Awake()
    {
        if (TD == null) {
            TD = this;
        }
    }

    public void PlayIt() {
        PD.Resume();
    }

    public void PauseIt() {
        PD.Pause();
    }
}
