using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    public int raycastlength;
    public GameObject button;

    public GameObject MartinButton;
    public GameObject Battery;
    public GameObject Martin;
    public GameObject Door;

void Update(){
//if mouse is clicked, we shoot a raycast
    if(Input.GetMouseButtonDown(0)){
        CheckRay();
    }

} 
    void CheckRay(){
//we check if the raycast has hit the button object, if it has, we trigger the doors closing/opening function
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        Debug.DrawRay(playerCam.transform.position, playerCam.ScreenToWorldPoint(Input.mousePosition), Color.red, 20);
        if(Physics.Raycast(ray, out Hit ,raycastlength)){
            if(Hit.transform == button.transform){
                Debug.Log("HIT");
                Door.GetComponent<Door>().ToggleDoor();
                Battery.GetComponent<BatteryControlHub>().DoorClosed = !Battery.GetComponent<BatteryControlHub>().DoorClosed;
            }
//or if we hit a martin button, his progress may have been stopped
            if(Hit.transform == MartinButton.transform){
                Martin.GetComponent<MartinScript>().DelayProgression();
            }
        }
    }


  

}
