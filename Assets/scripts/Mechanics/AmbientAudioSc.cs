using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioSc : MonoBehaviour
{
    AudioSource src;
    public List<AudioClip> Ambient;

    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
//checks if we already are playing a sound, if not, we play another one
        if(!src.isPlaying){
            src.clip = Ambient[0];
            src.Play();
        }
    }
}


































//SAM WAS HERE