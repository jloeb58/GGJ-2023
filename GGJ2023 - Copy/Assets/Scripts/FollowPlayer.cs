using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to be used for making the rain particle system follow the player without rotating
public class FollowPlayer : MonoBehaviour
{
    // Public Gameobject, assign the player object
    public GameObject player;

    // Private variable to store y-height
    private float yHeight;
    private Vector3 modifiedPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        yHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        modifiedPlayerPosition = player.transform.position + new Vector3(0, yHeight);
        transform.position = Vector3.MoveTowards(transform.position, modifiedPlayerPosition, 0.03f);
    }
}
