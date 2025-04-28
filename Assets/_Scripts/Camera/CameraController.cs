using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Position")]
    public Transform player;
    public Transform playersGhost;
    public float gap;
    public float height;
    public float width;
    

    [Header("Camera Rotation")]
    float XRotationAngle;
    float YRotationAngle;

    public float minVerAngle = -45;
    public float maxVerAngle = 45;

    bool ghostMode;

    private void Update()
    {
      
        XRotationAngle += Input.GetAxis("Mouse Y");
        XRotationAngle = Mathf.Clamp(XRotationAngle, minVerAngle, maxVerAngle);
        YRotationAngle += Input.GetAxis("Mouse X");

        
        Quaternion cameraRotation = Quaternion.Euler(XRotationAngle, YRotationAngle, 0f);

        // Apply the rotation to the camera
        transform.rotation = cameraRotation;

       
        Vector3 offset = cameraRotation * new Vector3(width, height, gap);
        if (!ghostMode)
        {
            
            transform.position = player.position - offset;
        }
        else
        {
            transform.position = playersGhost.position - offset;
        }
        
    }

    public Quaternion flatRotaion => Quaternion.Euler(0, YRotationAngle, 0); //property
    

    public bool setGhostMode(bool _ghostMode)
    {
       return ghostMode = _ghostMode;
    }

}
