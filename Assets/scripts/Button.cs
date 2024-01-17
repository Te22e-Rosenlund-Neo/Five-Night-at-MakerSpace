using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    public int raycastlength;
    public string ButtonTag;

    public GameObject Door;
    bool DoorOpen = true;

void Update(){
    if(Input.GetMouseButtonDown(0)){
        CheckRay();
    }
    if(DoorOpen == true){
        Door.GetComponent<MeshRenderer>().enabled = true;
    }else{
        Door.GetComponent<MeshRenderer>().enabled = false;
    }
} 
    void CheckRay(){
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        Debug.DrawRay(playerCam.transform.position, playerCam.ScreenToWorldPoint(Input.mousePosition), Color.red, 20);
        if(Physics.Raycast(ray, out Hit ,raycastlength)){
            if(Hit.transform.tag == ButtonTag){
                Debug.Log("HIT");
                ToggleDoor();
            }
        }
        

    }


    public void ToggleDoor(){
        if(DoorOpen == true){
            DoorOpen = false;
        }
        else if(DoorOpen == false){
            DoorOpen = true;
    }
}
}
