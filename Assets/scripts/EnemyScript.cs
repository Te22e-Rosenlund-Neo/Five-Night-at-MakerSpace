
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    public List<GameObject> points = new();
    public int AI_Level;
    private int timer = 0;
    private int Ai_max = 20; 
    public bool CanChangePosition = true;

    void Update(){
if(CanChangePosition == true){
    if(timer >= 360){
        if(ShouldSpawn(AI_Level, Ai_max) == true){
            Debug.Log("I moved");
            transform.position = RandomPosition(points).transform.position;
        }
        timer -= timer;
}


timer++;
}
    }
    GameObject RandomPosition(List<GameObject> points){
        //picks a random point in its list of walkable points
        int random = Random.Range(0,8);
        if(random == 0){
            
            GameObject Position = points[Random.Range(0, points.Count)];
            return Position;
        }else{
            return this.gameObject;
        }
    }

    bool ShouldSpawn(int AI_level, int AI_max){
        //compares if the enemy should walk depending on what difficulty it is on
        int random3 = Random.Range(0, AI_max);
        if(random3 < AI_level){
            return true;
        }
        return false;

    }
}
