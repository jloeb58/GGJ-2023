using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

// Script for Objective Item Collection functionality, is a component of the Player object
public class PlayerObjectives : MonoBehaviour
{
    // Player Input component that contains the controls, to be assigned in editor
    public PlayerInput playerInput;

    // Objective Objects to be assigned in the editor
    public GameObject objectiveWater;
    public GameObject objectiveSoil;
    public GameObject objectiveSunlight;

    // Objective Arrows to be hidden/shown
    public GameObject arrowWater;
    public GameObject arrowSoil;
    public GameObject arrowSunlight;

    // Private booleans to help us know if an objective is in the trigger collider
    private bool waterTriggerActive;
    private bool soilTriggerActive;
    private bool sunlightTriggerActive;

    // Private booleans to determine if objectives have been collected or not
    public bool waterCollected;
    public bool soilCollected;
    public bool sunlightCollected;

    // Start is called before the first frame update
    void Start()
    {
        // Set objectives to be active at the start of the script running
        objectiveWater.SetActive(true);
        objectiveSoil.SetActive(true);
        objectiveSunlight.SetActive(true);

        // Set the first objective arrow to true
        arrowWater.SetActive(true);

        // Set booleans to be false at game start
        waterTriggerActive = false;
        soilTriggerActive = false;
        sunlightTriggerActive = false;

        waterCollected = false;
        soilCollected = false;
        sunlightCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnTriggerEnter() and OnTriggerExit() is called when an object with a collider has entered/exited the Sphere Collider trigger component attached to this player
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Objective_Water")
        {
            waterTriggerActive = true;
        }
        else if (other.tag == "Objective_Soil")
        {
            soilTriggerActive = true;
        }
        else if (other.tag == "Objective_Sunlight")
        {
            sunlightTriggerActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Objective_Water")
        {
            waterTriggerActive = false;
        }
        else if (other.tag == "Objective_Soil")
        {
            soilTriggerActive = false;
        }
        else if (other.tag == "Objective_Sunlight")
        {
            sunlightTriggerActive = false;
        }
    }

    // Interact Key is "F", assigned in PlayerInput component. OnInteract() will be triggered by the Interact action from PlayerInput
    void OnInteract()
    {
        Debug.Log("Interact pressed");
        // If a TriggerActive boolean is true for an objective and the "F" key as been pressed, then hide that objective and change Collected boolean to true
        if (waterTriggerActive == true && waterCollected == false)
        {
            Debug.Log("Water collected");
            // objectiveWater.SetActive(false);
            waterTriggerActive = false;
            waterCollected = true;

            // New objective arrow
            arrowWater.SetActive(false);
            arrowSoil.SetActive(true);
        }
        else if (soilTriggerActive == true && soilCollected == false && waterCollected == true)
        {
            Debug.Log("Fertilizer collected");
            objectiveSoil.SetActive(false);
            soilTriggerActive = false;
            soilCollected = true;

            // New objective arrow
            arrowSoil.SetActive(false);
            arrowSunlight.SetActive(true);
        }
        else if (sunlightTriggerActive == true && waterCollected == true && soilCollected == true)
        {
            Debug.Log("Sunlight collected");
            objectiveSunlight.SetActive(false);
            sunlightTriggerActive = false;
            sunlightCollected = true;

            arrowSunlight.SetActive(false);
        }
    }

}
