using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NouseAudioSc : MonoBehaviour
{
    AudioSource src;
    bool change = false;
    void Start()
    {
        src = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
//Plays noise
        if(change == true){ 
            src.Play();
            change = false;
        }
    }
    public void NoiseChange(AudioClip clip){
//is called when an audio should play on distance
        src.clip = clip;
        change = true;
    }
    
}
