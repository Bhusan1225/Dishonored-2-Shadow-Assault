using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    GameObject ghostZoneUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GhostZone"))
        {
            ghostZoneUI.SetActive(true);
        }
        else
        {
            ghostZoneUI.SetActive(false);
        }
    }
}
