using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxiScript : MonoBehaviour
{
   public List<GameObject> MaxiPoints;
    public Animator animator;
    public string AnimName;
    public int Stage;

    private float timer;
    private float maxtime = 6f;

    public int CamCount;
    void Update()
    {
        Animation();
        
        if(CamCount == 4){
            Counter();
        }
       
        if(timer == 0){
            Stage += 1;
            timer = maxtime;
            int MoveChance = Random.Range(1,3);

            if(MoveChance == 3){
                int MoveRandom = Random.Range(0, MaxiPoints.Count-1);
                transform.position = MaxiPoints[MoveRandom].transform.position;
                transform.rotation = MaxiPoints[MoveRandom].transform.rotation;
            }
        }


    int move = Random.Range(1,16);
    

    }
    void Animation(){
        if(Stage == 1){
            animator.SetFloat(AnimName, Stage);
        }
    }
    public void ResetProgress(){
        Stage = 0;
        CamCount = 0;
    }
    void Counter(){
timer += Time.deltaTime;
    }
    
}
