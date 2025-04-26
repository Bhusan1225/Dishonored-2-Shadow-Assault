using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavigationScript : MonoBehaviour
{
    [Header("Character Info")]
    public float movingSpeed;
    public float turningSpeed = 300f;
    public float stopSpeed = 1f;


    [Header("Destination var")]
    public Vector3 destination;
    public bool destinationReached;

    private void Update()
    {
        Walk();
    }
    public void Walk()
    {
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;    
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopSpeed) 
            { 
                destinationReached = false;
                Quaternion targetRotaion = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotaion, turningSpeed * Time.deltaTime);

                //Moving AI
                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
            }
            else
            {
                destinationReached = true;
            }
        }
    }

    public void LocateDestination(Vector3 destination)
    {
        this .destination = destination;    
        destinationReached = false; 
    }
}
