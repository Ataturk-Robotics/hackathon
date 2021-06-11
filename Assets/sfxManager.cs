using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> clips = new List<AudioClip>();

    private void Start() {
    }

    public void playSoundById(int id){
        audioSource.clip = clips[id];
        audioSource.Play();
    }
}
