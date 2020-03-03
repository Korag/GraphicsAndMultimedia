using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Reference the player
    public GameObject player;

    // Position of our camera
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Where we moved the camera in our scene
        offset = transform.position;
    }

    // LateUpdate is called once per frame
    // But at the end of a frame
    void LateUpdate()
    {
        // Out initial position, plus the updated player position
        transform.position = player.transform.position + offset;
    }
}
