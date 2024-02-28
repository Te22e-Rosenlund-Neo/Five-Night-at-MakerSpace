using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    public List<GameObject> AnimationChangePoints;
    public Animator animator;

    public string ConditionName;

    void Update(){
        foreach(GameObject point in AnimationChangePoints){
            if(point.transform.position == transform.position){
                animator.SetBool(ConditionName, true);
            }else{
                animator.SetBool(ConditionName, false);
            }
        }



    }
}
