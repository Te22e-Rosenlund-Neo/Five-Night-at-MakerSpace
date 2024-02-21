
using System;
using System.Collections;
using System.Collections.Generic;
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
                GameObject moveto = RandomPosition();
                transform.position = moveto.transform.position;
                transform.rotation = moveto.transform.rotation;


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
    GameObject RandomPosition()
    {
        //moves to a random target within the current nodes proximity by checking inside corresponding name
        //to keep track of which node we are at in the array, we connect target name to a name in points array and sets pos to that number
    int Target = UnityEngine.Random.Range(0, SecondPoints[CurrentNode].SecPoints.Count);
        GameObject NewPosition = SecondPoints[CurrentNode].SecPoints[Target];
        for(int i = points.Count-1; i >= 0; i--){
            if(points[i].transform.name == NewPosition.transform.name){
                CurrentNode = i;
                Debug.Log(transform.name + CurrentNode);
                Debug.Log(transform.name + NewPosition.transform.name);
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


