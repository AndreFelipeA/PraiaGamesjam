using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
        private AudioClip scareClip;
        [SerializeField] AudioClip[] scare;
        public AudioClip die;
        public AudioClip bite;
        private AudioSource audioSource;
        


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayScare()
    {
        int index = Random.Range(0, 3);
        scareClip = scare[index];

        audioSource.clip = scareClip;
        audioSource.Play();
    }

    public void PlayDie()
    {
        audioSource.clip = die;
        audioSource.Play();
    }

    public void PlayBite()
    {
        audioSource.clip = bite;
        audioSource.Play();
    }
}
