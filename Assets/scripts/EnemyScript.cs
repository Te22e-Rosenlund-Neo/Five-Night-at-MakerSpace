
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
    public int timer;
    void Update(){

if(timer >= 120){
    if(ShouldSpawn(AI_Level) == true){
        Debug.Log("I moved");
        transform.position = RandomPosition(points).transform.position;
    }


    timer -= timer;
}


timer++;
    }
    GameObject RandomPosition(List<GameObject> points){
        
        int random = Random.Range(0,8);
        if(random == 0){
            
            GameObject Position = points[Random.Range(0, points.Count)];
            return Position;
        }else{
            return this.gameObject;
        }
    }

    bool ShouldSpawn(int AI_level){

        int random3 = Random.Range(0, 20);
        if(random3 < AI_level){
            return true;
        }
        return false;

    }
}
