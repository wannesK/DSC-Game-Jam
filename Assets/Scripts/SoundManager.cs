using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public static AudioClip sword, swordImpact;
    private static AudioSource audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        sword = Resources.Load<AudioClip>("Sword");
        swordImpact = Resources.Load<AudioClip>("SwordImpact");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Sword":
                audioSource.PlayOneShot(sword);
                break;
            case "SwordImpact":
                audioSource.PlayOneShot(swordImpact);
                break;
            default:
                break;
        }
    }
}
