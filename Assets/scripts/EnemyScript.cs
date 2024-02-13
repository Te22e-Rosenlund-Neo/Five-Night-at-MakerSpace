
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    public List<GameObject> points = new();
    public List<GameObject> JumpScarePoints;
    public int AI_Level;
    public float MoveCheckDistance;

    public float StartTime;
    private float timer;

    void Awake()
    {
        //sets enemy pos to be its start pos
        transform.position = points[0].transform.position;
        timer = StartTime;
    }

    void Update()
    {
        //checks if the timer for move is 0, then checks if it should move, then moves.
        if (timer <= 0)
        {
            timer = StartTime;
            if (ShouldMove() == true)
            {

                transform.position = RandomPosition(points).transform.position;

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
    GameObject RandomPosition(List<GameObject> points)
    {
        List<GameObject> ValidMoveTargets = new();
    //we check between all moveable targets is close enough for the enemy to logically move to, if it is, we randomize a new positions from one of those

        foreach(GameObject point in points){
            if(Vector3.Distance(point.transform.position, transform.position) < MoveCheckDistance){
                ValidMoveTargets.Add(point);
            }
        }
    int Target = Random.Range(0, ValidMoveTargets.Count);
        GameObject NewPosition = points[Target];
        ValidMoveTargets.Clear();   
        Debug.Log("I moved");
        return NewPosition;
    }



    //randomizes if the enemy should move
    bool ShouldMove()
    {

        int RandomOdd = Random.Range(0, points.Count);

        if (AI_Level >= RandomOdd)
        {
            return true;
        }
        return false;
    }

}
