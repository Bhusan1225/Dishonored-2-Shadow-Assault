using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMode : MonoBehaviour
{

    [SerializeField] GameObject StartUI;
    [SerializeField] GameObject IntroUI;

    // Start is called before the first frame update
    void Start()
    {
        StartUI.SetActive(true);
        StartCoroutine("StoryIntro", 5f);
    }

    private IEnumerator StoryIntro()
    {
        yield return new WaitForSeconds(5f);
        IntroUI.SetActive(true);
        StartUI.SetActive(false);
        yield return new WaitForSeconds(2f);
        IntroUI.SetActive(false);


    }

    
}
