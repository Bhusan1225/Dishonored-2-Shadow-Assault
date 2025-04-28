using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMode : MonoBehaviour
{


    [SerializeField]
    bool ghostModeOn;

    [SerializeField]
    GameObject ghostEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ghostModeOn = true;
            ghostEffect.SetActive(true);

            StartCoroutine("DeactivateGhostMode", 10f);

        }
    }


    private IEnumerator DeactivateGhostMode()
    {
        yield return new WaitForSeconds(10f);
        ghostEffect.SetActive(false);
        ghostModeOn = false;

    }
}
