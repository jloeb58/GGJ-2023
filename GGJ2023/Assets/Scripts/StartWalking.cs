using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class StartWalking : MonoBehaviour
{
    private Animator Animde;

    // Start is called before the first frame update
    void Start()
    {
        Animde = GetComponent<Animator>();
        Animde.speed = .5f;
    }

    // Update is called once per frame
    void Update()
    {
        Animde.SetTrigger("Walking");
    }
}
