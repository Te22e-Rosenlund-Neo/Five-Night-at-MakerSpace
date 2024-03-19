using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NouseAudioSc : MonoBehaviour
{
    AudioSource src;
    bool change = true;
    void Start()
    {
        src = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(change == true){
            src.Play();
            change = false;
        }
    }
    public void NoiseChange(AudioClip clip){
        src.clip = clip;
        change = true;
    }
    
}
