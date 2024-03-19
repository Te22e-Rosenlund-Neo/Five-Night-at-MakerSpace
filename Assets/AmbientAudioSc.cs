using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioSc : MonoBehaviour
{
    AudioSource src;
    public AudioClip[] Ambient = new AudioClip[3];

    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!src.isPlaying){
            src.clip = Ambient[Random.Range(0, Ambient.Length-1)];
            src.Play();
        }
    }
}
