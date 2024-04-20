using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EttanBehaviour : MonoBehaviour
{
    public GameObject Player;
    public Camera PlayerCam;
    public GameObject Maxi;

    public GameObject CommandPanel;

    void Start(){
//panel that displays "Press "E" to use"
        CommandPanel.SetActive(false);
    }
    void Update(){
//if we are close enough to the object, we send raycasts to see if we are looking at a snus, if we are we display press "E"
//if player presses E, he picks up snus and it is removed
        if(Vector3.Distance(Player.transform.position, transform.position) < 1.5f){
            Ray ray = PlayerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;
            if(Physics.Raycast(ray, out HitInfo, 1000)){
                if(HitInfo.transform == transform){
//makes sure we don't already have a snus
                    if(Player.GetComponent<PlayerMovement>().SnusCount == 0){
                        CommandPanel.SetActive(true);
                        if(Input.GetKeyDown(KeyCode.E)){
                            CommandPanel.SetActive(false);
                            HitInfo.transform.gameObject.SetActive(false);
                            Player.GetComponent<PlayerMovement>().SnusCount += 1;
                        }
                    }else{
                        CommandPanel.SetActive(false);
                    }
                }else{
                    CommandPanel.SetActive(false);
                }
            }
        }
//if we are close enough to give maxi snus
        if(Vector3.Distance(Player.transform.position, Maxi.transform.position) < 3f){
            GiveMaxi();
        }
    }
    void GiveMaxi(){
//checks if we are looking at a window with maxi in, then prompts player to  give him snus
            Ray RayMaxiWIndow = PlayerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfomaxi;
            if(Physics.Raycast(RayMaxiWIndow, out HitInfomaxi, 1000)){
                Debug.Log(HitInfomaxi.transform.name);
                if(HitInfomaxi.transform == Maxi.GetComponent<MaxiScript>().CurrentWindow.transform){
                    if(Player.GetComponent<PlayerMovement>().SnusCount == 1){
                        CommandPanel.SetActive(true);
                        if(Input.GetKeyDown(KeyCode.E)){
                            CommandPanel.SetActive(false);
                            Player.GetComponent<PlayerMovement>().SnusCount -= 1;
                            Maxi.GetComponent<MaxiScript>().ResetProgress();
                            Maxi.GetComponent<MaxiScript>().CurrentWindow.SetActive(false);
                        }
                    }else{
                        CommandPanel.SetActive(false);
                    }
                }else{
                    CommandPanel.SetActive(false);
                }
            }
        }
}
