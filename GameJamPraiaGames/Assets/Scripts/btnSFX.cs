using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSFX : MonoBehaviour
{
    // Start is called before the first frame update
    
    public AudioSource audioSource;
    public AudioClip onHover;
    public AudioClip onClick;

    public void HoverSound()
    {
        audioSource.PlayOneShot(onHover);
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(onClick);
    }
}
