using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextManager : MonoBehaviour
{
    private static TutorialTextManager instance;

    public GameObject tutorialText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            tutorialText.SetActive(true);
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void DisableTextButton()
    {
        tutorialText.SetActive(false);
    }

}
