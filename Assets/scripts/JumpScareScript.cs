using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework.Internal;
using UnityEngine;

public class JumpScareScript : MonoBehaviour
{


private float timer = 50f;

public Camera playerCam;

public GameObject Player;

public GameObject ScareFolder;

public GameObject ChangeCamera;

public int raycastlength;

public Animator animator;
bool start = false;

void Update(){
  //if countdown to death is starting
if(start == true){
      Debug.Log("Starting timer for death");
      
  //if player looks at camera, death is postponed
        if(ChangeCamera.GetComponent<CameraSystem>().CamOn == false){
          DeathScene();
        }
  //if player hasn't looked at enemy within 10seconds, he dies anyway
        if(timer <= 0){
          DeathScene();
        }

timer -= Time.deltaTime;
}
}
//starts the jumpscare section, and disables further enemy movement
public void JumpScare(){
   start = true;
   GetComponent<EnemyScript>().enabled = false;
}
void DeathScene(){
    animator.SetBool("Death", true);
    ScareFolder.SetActive(true);
    Debug.Log("Death");
    Player.GetComponent<PlayerMovement>().enabled = false;
}

}
