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
        CommandPanel.SetActive(false);
    }
    void Update(){
        if(Vector3.Distance(Player.transform.position, transform.position) < 1.5f){
            Ray ray = PlayerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;
            if(Physics.Raycast(ray, out HitInfo, 1000)){
                if(HitInfo.transform == transform){
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
        if(Vector3.Distance(Player.transform.position, Maxi.transform.position) < 3f){
            GiveMaxi();
        }
    }
    void GiveMaxi(){
        
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
