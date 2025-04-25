using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Position")]
    public Transform target;
    public float gap;
    public float height;
    public float width;
    

    [Header("Camera Rotation")]
    float XRotationAngle;
    float YRotationAngle;

    public float minVerAngle = -45;
    public float maxVerAngle = 45;

    private void Update()
    {
        // Update the rotation angles based on mouse input
        XRotationAngle += Input.GetAxis("Mouse Y");
        XRotationAngle = Mathf.Clamp(XRotationAngle, minVerAngle, maxVerAngle);
        YRotationAngle += Input.GetAxis("Mouse X");

        // Create a new Quaternion for the camera's rotation using the updated angles
        Quaternion cameraRotation = Quaternion.Euler(XRotationAngle, YRotationAngle, 0f);

        // Apply the rotation to the camera
        transform.rotation = cameraRotation;

        // Calculate the new camera position offset from the target
        Vector3 offset = cameraRotation * new Vector3(width, height, gap);

        // Set the new camera position relative to the target
        transform.position = target.position - offset;
    }

    public Quaternion flatRotaion => Quaternion.Euler(0, YRotationAngle, 0); //property
    

}
