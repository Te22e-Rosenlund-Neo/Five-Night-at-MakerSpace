using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.EditorTools;
using UnityEditor.Rendering;
using UnityEngine;

public class MartinScript : MonoBehaviour
{
    public float timer;
    public float StartTime = 7f;
    public float TimeDelay = 30f;
    public List<GameObject> martinParts;
    public List<GameObject> CurrentTaskBarStages;
    public GameObject Battery;
    int State = 0;
    int TaskState = 0;
    bool allowedDelay = true;
    [Header("Sfx")]
    public GameObject ChangeAudio;
    public AudioClip Finished;
    
  
    void Start(){
        timer = StartTime;
    }
    void Update()
    {
//when timer has reached 0  4times, a part of him is completed, if 4 are completed, he breaks loose
        if(timer <= 0){
            foreach(GameObject P in CurrentTaskBarStages){
                P.SetActive(false);
            }
            CurrentTaskBarStages[TaskState].SetActive(true);
            Debug.Log(State + TaskState + " just ran");
            timer = StartTime;
            TaskState ++;
            allowedDelay = true;
        }
        if(TaskState == 4){
            CompletePrint();
            State ++;
        }
        if(State == 4){
            GetComponent<JumpScareScript>().JumpScare();
        }
        
        timer -= Time.deltaTime;
    }
    //plays a finsihed audio sound, shows that part of him, resets progress on other printers
    void CompletePrint(){
        ChangeAudio.GetComponent<NouseAudioSc>().NoiseChange(Finished);
        Debug.Log("completed print" + State);
        martinParts[State].SetActive(true);
        TaskState = 0;
        foreach(GameObject P in CurrentTaskBarStages){
            P.SetActive(false);
        }
    }
    public void DelayProgression(){
//if player can delay martins progression, then he can click button to do so
        if(allowedDelay == true){
            timer = TimeDelay;
            Battery.GetComponent<BatteryControlHub>().BatteryLevel = Battery.GetComponent<BatteryControlHub>().BatteryLevel * 0.95f;
            allowedDelay = false;
        }  
    }
}
