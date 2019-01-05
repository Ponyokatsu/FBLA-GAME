﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player; 

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;
    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    private Vector3 offset;         //offset distance between player and camera

    void Start()
    {
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (GameObject.Find("Player") != null && GameController.level != 2)
        {
            transform.position = player.transform.position + offset;


            float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}