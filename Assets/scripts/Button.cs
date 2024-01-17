using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    public int raycastlength;
    public string ButtonTag;
    public GameObject button;

    public GameObject Door;

void Update(){
    if(Input.GetMouseButtonDown(0)){
        CheckRay();
    }

} 
    void CheckRay(){
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        Debug.DrawRay(playerCam.transform.position, playerCam.ScreenToWorldPoint(Input.mousePosition), Color.red, 20);
        if(Physics.Raycast(ray, out Hit ,raycastlength)){
            if(Hit.transform == button.transform){
                Debug.Log("HIT");
                Door.GetComponent<Door>().ToggleDoor();
            }
        }
    }


  

}
