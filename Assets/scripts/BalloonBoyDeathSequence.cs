using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BalloonBoyDeathSequence : MonoBehaviour
{
    public List<GameObject> lights;
    public GameObject BalloonboyFocus;

    float timer = 10f;
    public AudioClip Music;
    public AudioSource src;

    public bool start = false;
    void Start(){
        BalloonboyFocus.SetActive(false);
        src.clip = Music;
    }
    void Update()
    {
    
    if(start == true){
        src.Play();
        timer -= Time.deltaTime;
        foreach(GameObject light in lights){
            light.SetActive(false);
        }
        BalloonboyFocus.SetActive(true);
    }
    if(timer <= 0){
        GetComponent<JumpScareScript>().JumpScare();
    }
    }
}
