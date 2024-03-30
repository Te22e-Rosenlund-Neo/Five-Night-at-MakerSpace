using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndCutscene : MonoBehaviour
{
   public float timer = 0; 
   public AudioSource src;
    void Update()
    {
        if(timer >= 22){
            SceneManager.LoadScene(0);
        }
        if(timer >= 17){
            src.volume -= Time.deltaTime/5;
        }



timer += Time.deltaTime; 
    }
}
