using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostMode : MonoBehaviour
{


    //player
    [Header("Player ")]
    [SerializeField]
    PlayerHealth health;
    [SerializeField]
    GameObject player;
    [SerializeField]
    CameraController cameraController;

    //Ghost
    [Header("Ghost Mode")]
    [SerializeField]
    GameObject playerGhost;
    
    
    [SerializeField]
    bool ghostModeOn;

    [SerializeField]
    GameObject ghostEffect;

    //private void Update()
    ////{
    ////    if (ghostModeOn)
    ////    {
            
    ////        playerGhost.SetActive(true);
    ////        health.setMaxHealth(100);
    ////        player.SetActive(false);
    ////        cameraController.setGhostMode(true);

          
    ////    }
    ////    else
    ////    {
           
           
    ////    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            ghostModeOn = true;
            playerGhost.SetActive(true);
            health.setMaxHealth(100);
            player.SetActive(false);
            cameraController.setGhostMode(true);

            StartCoroutine("DeactivateGhostMode", 10f);

        }
    }


    private IEnumerator DeactivateGhostMode()
    {
        yield return new WaitForSeconds(30f);
        ghostEffect.SetActive(false);
        ghostModeOn = false;
        health.setMaxHealth(10);
    }
}
