using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class JumpScareScript : MonoBehaviour
{


private float timer = 50f;

public Camera playerCam;

public GameObject Player;

public GameObject ScareFolder;

public GameObject Enemy;

public int raycastlength;

public Animator animator;
bool start = false;

void Update(){
  //if countdown to death is starting
if(start == true){
      Debug.Log("Starting timer for death");
      Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
  //if player looks at enemy, he dies
        if(Physics.Raycast(ray, out Hit ,raycastlength)){
          Debug.Log(Hit.transform.name);
            if(Hit.transform == Enemy.transform){
                DeathScene();
            }
              
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
