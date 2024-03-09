using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.EditorTools;
using UnityEngine;

public class MartinScript : MonoBehaviour
{
    public float timer;
    public float StartTime = 25f;
    public List<GameObject> martinParts;
    public List<GameObject> CurrentTaskBarStages;
    int State = 0;
    int TaskState = 0;

  
    void Start(){
        timer = StartTime;
    }
    void Update()
    {
        if(timer <= 0){
            TaskState ++;
            foreach(GameObject P in CurrentTaskBarStages){
                P.SetActive(false);
            }
            CurrentTaskBarStages[TaskState].SetActive(true);
        }
        if(TaskState == 3){
            CompletePrint(State);
            State ++;
        }
        if(State == 3){
            GetComponent<JumpScareScript>().JumpScare();
        }
        
        timer -= Time.deltaTime;
    }
    void CompletePrint(int state){
        martinParts[state].SetActive(true);
    }
}
