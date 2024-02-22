
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
[Serializable]
public class SecondaryPoints{
    public List<GameObject> SecPoints = new();
}

public class EnemyScript : MonoBehaviour
{
    public List<GameObject> points = new();
    

    public List<SecondaryPoints> SecondPoints = new();
    public List<GameObject> JumpScarePoints;
    public int AI_Level;

    public float StartTime;
    private float timer;

    int CurrentNode;
    string CurrentNodeName;

    void Awake()
    {
        //sets enemy pos to be its start pos
        transform.position = points[0].transform.position;
        transform.rotation = points[0].transform.rotation;
        CurrentNode = 0;
        timer = StartTime;

    }

    void Update()
    {

        // checks if the timer for move is 0, then checks if it should move, then moves.
        if (timer <= 0)
        {
            timer = StartTime;
            if (ShouldMove() == true)
            {
                Transform moveto = RandomPosition();
                transform.position = moveto.position;
                transform.rotation = moveto.rotation;


                foreach (GameObject JSP in JumpScarePoints)
                {
                    if (JSP.transform.position == transform.position)
                    {
                        GetComponent<JumpScareScript>().JumpScare();
                    }
                }
            }
        }

        timer -= Time.deltaTime;
    }

    //randomizes what way the enemy moves 
    Transform RandomPosition()
    {
        int RandomTarget = UnityEngine.Random.Range(0, SecondPoints[CurrentNode].SecPoints.Count);
        Transform NewPosition = SecondPoints[CurrentNode].SecPoints[CurrentNode].transform;

        foreach(GameObject tr in SecondPoints[CurrentNode].SecPoints){
            if(tr.transform == NewPosition){
                
            }
        }
        return NewPosition;
    }



    //randomizes if the enemy should move
    bool ShouldMove()
    {

        int RandomOdd = UnityEngine.Random.Range(0, points.Count);

        if (AI_Level >= RandomOdd)
        {
            return true;
        }
        return false;
    }

}



