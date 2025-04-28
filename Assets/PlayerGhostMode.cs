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

    private void Update()
    {
        if (ghostModeOn)
        {
            
            playerGhost.SetActive(true);
            health.setMaxHealth(1000);
            player.SetActive(false);
            cameraController.setGhostMode(true);

          
        }
        else
        {
            health.setMaxHealth(100);
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            ghostModeOn = true;
            playerGhost.SetActive(true);

            StartCoroutine("DeactivateGhostMode", 100f);

        }
    }


    private IEnumerator DeactivateGhostMode()
    {
        yield return new WaitForSeconds(100f);
        ghostEffect.SetActive(false);
        ghostModeOn = false;
        
    }
}
