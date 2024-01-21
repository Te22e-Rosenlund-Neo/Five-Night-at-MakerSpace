using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    bool DoorOpen = false;
    [SerializeField] float timeToOpen;
    [Header("2 Door Positions")]
    [SerializeField] Vector3 Top;
    [SerializeField] Vector3 Bottom;
    float time = 0;
  
    void FixedUpdate(){
        if(time < timeToOpen){
            if(DoorOpen == false){
                transform.position = Vector3.Lerp(Bottom, Top, time/timeToOpen);
            }else{
                transform.position = Vector3.Lerp(Top, Bottom, time/timeToOpen);
            }
            time += Time.deltaTime;
        }
      

    
}
public void ToggleDoor()
    {
     time = 0;
     if(DoorOpen == false){
        DoorOpen = true;
     }else{
        DoorOpen = false;
    }
}
}















