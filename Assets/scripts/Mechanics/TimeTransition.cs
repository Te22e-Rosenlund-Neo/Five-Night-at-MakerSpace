using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TimeTransition : MonoBehaviour
{
    public TMP_Text Start;
    public TMP_Text Stop;
    string key = "NightLoad";
    public float ScaleDifferense = 0.001f;
     float StartNewer;
     float StopNewer = 0;
     public float StopExit;
     public float timer;
//function is the win screen
    void Awake()
    {
        StartNewer = Start.transform.localScale.y;
    }
    void FixedUpdate()
    {

//flips the number 5 over to become a 6
        if (Start.transform.localScale.y > 0)
        {
            Start.transform.localScale = new Vector3(Start.transform.localScale.x, StartNewer, Start.transform.localScale.z);
            StartNewer -= ScaleDifferense;
        }
        if(Start.transform.localScale.y <= 0 && StopNewer <= StopExit){
            Stop.transform.localScale = new Vector3(Stop.transform.localScale.x, StopNewer, Stop.transform.localScale.z);
            StopNewer += ScaleDifferense;
        }   
    timer += Time.deltaTime;
//if player has beaten all nights, we set win screen to be end cutscene
    if(timer >= 6){
        if(PlayerPrefs.GetInt(key) >= 6){
            SceneManager.LoadSceneAsync(3);
        }else{
        SceneManager.LoadSceneAsync(0);
        }
    }
    }
}
