using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxiScript : MonoBehaviour
{
   public List<GameObject> MaxiPoints;
    public Animator animator;
    public string AnimName;
    public int Stage;

    public float timer;
    public float maxtime = 6f;

    public int CamCheckMax;

    public int CamCount;

    public GameObject CurrentWindow;

    void Start(){
        transform.position = MaxiPoints[3].transform.position;
        transform.rotation = MaxiPoints[3].transform.rotation;
        CurrentWindow = MaxiPoints[3].GetComponent<WindowHeritage>().WindowParent;
    }
    void Update()
    {
        Animation();
        
        if(CamCount >= CamCheckMax){
            Counter();
        }
       
        if(timer <= 0){
            Stage += 1;
            timer = maxtime;
            int MoveChance = Random.Range(1,4);
            Debug.Log(MoveChance);
            if(MoveChance == 3){                
                int MoveRandom = Random.Range(0, MaxiPoints.Count-1);
                transform.position = MaxiPoints[MoveRandom].transform.position;
                transform.rotation = MaxiPoints[MoveRandom].transform.rotation;
                CurrentWindow = MaxiPoints[MoveRandom].GetComponent<WindowHeritage>().WindowParent;
            }   
            if(Stage >= 4){
                GetComponent<JumpScareScript>().JumpScare();
            }
        }
    }
    void Animation(){
            animator.SetFloat(AnimName, Stage);
        
    }
    public void ResetProgress(){
        Stage = 0;
        CamCount = 0;
    }
    void Counter(){
timer -= Time.deltaTime;
    }
    
}
