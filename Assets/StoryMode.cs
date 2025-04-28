using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMode : MonoBehaviour
{

    [SerializeField] GameObject startUI;
    [SerializeField] GameObject introUI;
    [SerializeField] GameObject guideUI;

    // Start is called before the first frame update
    void Start()
    {
        startUI.SetActive(true);
        StartCoroutine("StoryIntro", 5f);
    }

    private IEnumerator StoryIntro()
    {
        yield return new WaitForSeconds(3f);
        introUI.SetActive(true);
        startUI.SetActive(false);
        yield return new WaitForSeconds(3f);
        guideUI.SetActive(true);
        introUI.SetActive(false);
        yield return new WaitForSeconds(3f);
        guideUI.SetActive(false);

    }

    
}
