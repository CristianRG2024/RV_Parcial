using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    public void playAudio(AudioClip audio) {
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void playAudioFX(AudioClip audio) { 
        audioSource.PlayOneShot(audio);
    }
}
