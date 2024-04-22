using System.Collections.Generic;
using UnityEngine;

public class TileRotation : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 90f;

    // Flag to check if the tile is currently rotating
    private bool isRotating = false;

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click and start rotating if not already rotating
        if (Input.GetMouseButtonDown(0) && !isRotating)
        {
            // Rotate the tile
            RotateTile();
        }
    }

    // Rotate the tile
    void RotateTile()
    {
        // Set rotating flag to true
        isRotating = true;

        // Calculate the target rotation angle (90 degrees clockwise)
        float targetAngle = transform.eulerAngles.z - 90f;

        // Rotate the tile smoothly towards the target angle
        StartCoroutine(RotateTowardsAngle(targetAngle));
    }

    
    // Coroutine to smoothly rotate the tile towards the target angle
     
    IEnumerator RotateTowardsAngle (float targetAngle)
    {
        // Get the current rotation angle
        float currentAngle = transform.eulerAngles.z;

        // Loop until the tile reaches the target angle
        while (Mathf.Abs(currentAngle - targetAngle) > 0.01f)
        {
            // Calculate the new rotation angle based on the rotation speed and time
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);

            // Apply the new rotation
            transform.eulerAngles = new Vector3(0, 0, newAngle);

            // Update the current rotation angle
            currentAngle = newAngle;

            // Wait for the end of the frame
            yield return null;
        }

        // Set rotating flag to false
        isRotating = false;
    }

    // This function is called when the object becomes clickable
    private void OnMouseDown()
    {
        // Check if the tile is not already rotating
        if (!isRotating)
        {
            // Rotate the tile
            RotateTile();
        }
    }
}