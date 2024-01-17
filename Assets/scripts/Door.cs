using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    bool DoorOpen = false;
    [Header("2 Door Positions")]
    [SerializeField] Vector3 Top;
    [SerializeField] Vector3 Bottom;
    Vector3 Target;
void Awake(){
    Target = Bottom;
}
void Update(){
    if(transform.position != Target){
        transform.position = Vector3.MoveTowards(transform.position, Target, 0.02f);
    }
}

public void ToggleDoor(){
    if(DoorOpen == false){
        Target = Top;
        DoorOpen = true;
    }else{
        Target = Bottom;
        DoorOpen = false;
    }
}

}
















