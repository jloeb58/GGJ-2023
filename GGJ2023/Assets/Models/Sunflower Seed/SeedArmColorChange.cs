using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedArmColorChange : MonoBehaviour
{
    public PlayerObjectives playerObjective;

    public ParticleSystem waterCollectParticleSystem;
    public ParticleSystem fertCollectParticleSystem;

    private Material seedArmMat;
    private SkinnedMeshRenderer seedArmMesh;

    private bool waterCollected;
    private bool soilCollected;

    // Start is called before the first frame update
    void Start()
    {
        seedArmMat = GetComponent<Material>();
        seedArmMesh = GetComponent<SkinnedMeshRenderer>();
        seedArmMesh.enabled = false;
        waterCollected = false;
        soilCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waterCollected && playerObjective.waterCollected)
        {
            waterCollected = true;
            seedArmMesh.enabled = true;
            waterCollectParticleSystem.Play();
            Invoke("hideArm", 5);
        }
        if (!soilCollected && playerObjective.soilCollected)
        {
            soilCollected = true;
            seedArmMesh.enabled = true;
            fertCollectParticleSystem.Play();
            Invoke("hideArm", 5);
        }
    }

    void hideArm()
    {
        seedArmMesh.enabled = false;
    }
}
