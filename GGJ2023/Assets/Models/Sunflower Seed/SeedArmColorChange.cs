using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedArmColorChange : MonoBehaviour
{
    public PlayerObjectives playerObjective;
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
        if (playerObjective.waterCollected && !waterCollected)
        {
            waterCollected = true;
            seedArmMesh.enabled = true;
            Invoke("hideArm", 7);
        }
        if (playerObjective.soilCollected && !soilCollected)
        {
            soilCollected = true;
            seedArmMesh.enabled = true;
            Invoke("hideArm", 7);
        }
    }

    void hideArm()
    {
        seedArmMesh.enabled = false;
    }
}
