using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BalloonBoyDeathSequence : MonoBehaviour
{
    public List<GameObject> lights;
    public GameObject BalloonboyFocus;

    float timer;
    public AudioClip Music;
    public AudioSource src;

    public bool start = false;
    void Start(){
        timer = Random.Range(6, 16);
        BalloonboyFocus.SetActive(false);
        src.clip = Music;
    }
    void Update()
    {
//if baloon boy has been triggered, audio plays, all lights are turned of and one light above him is highlighted
    if(start == true){
        src.Play();
        timer -= Time.deltaTime;
        foreach(GameObject light in lights){
            light.SetActive(false);
        }
        BalloonboyFocus.SetActive(true);
    }
//after 10 seconds, we play the jumpscare
    if(timer <= 0){
        GetComponent<JumpScareScript>().JumpScare();
    }
    }
}
