using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DontExit : MonoBehaviour
{   
    public string PlayerTag;
//if player attempts to exit the main room, he dies!
    void OnTriggerEnter(Collider other)
    {

        if(other.transform.tag == PlayerTag){
                    Debug.Log("enter");
            GetComponent<JumpScareScript>().JumpScare();
        }
    }
    
}
