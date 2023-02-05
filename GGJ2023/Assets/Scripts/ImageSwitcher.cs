using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public GameObject unC;
    public GameObject Cl;
    private bool unCActive;
    private float qT;

    void OnEnable()
    {
        qT = 1;
        unCActive = true;
        unC.SetActive(true);
        Cl.SetActive(false);
        TimelineDirector.TD.PauseIt();
    }

    void Update()
    {
        if (Input.GetKeyDown("left") || Input.GetKeyDown("w")) {
            TimelineDirector.TD.PlayIt();
        }

        qT -= Time.deltaTime;

        if (qT <= 0) {
            if (unCActive) {
                qT = 1;
                unC.SetActive(false);
                Cl.SetActive(true);
                unCActive = false;
            }
            else if (unCActive == false) {
                qT = 1;
                unC.SetActive(true);
                Cl.SetActive(false);
                unCActive = true;
            }
        }
    }
}
