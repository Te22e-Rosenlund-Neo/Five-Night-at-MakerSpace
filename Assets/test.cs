using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class test : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    public Camera PlayerCam;
    public Canvas canvas;
    public GameObject Player;

    List<Camera> AllCameras = new List<Camera>();
    private bool CamOn = true;
    
    void Start(){
        cam1.enabled = false;
        cam2.enabled = false;
        canvas.enabled = false;

        AllCameras.Add(cam1);
        AllCameras.Add(cam2);
        AllCameras.Add(PlayerCam);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            ToggleCam();
        }
    }
    public void ToggleCam(){
        if(CamOn == false){
            CamOn = true;
            SwitchCam1();
            canvas.enabled = true;
            Player.GetComponent<PlayerMovement>().enabled = false;
        }else{
            CamOn = false;
            SwapToPlayerView();
            canvas.enabled = false;
            Player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
    
    public void SwitchCam1(){

        foreach(Camera cam in AllCameras){
            cam.enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cam1.enabled = true;
        
        
    }
    public void SwitchCam2(){
        foreach(Camera cam in AllCameras){
             cam.enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cam2.enabled = true;
    }
    public void SwapToPlayerView(){
         foreach(Camera cam in AllCameras){
             cam.enabled = false;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCam.enabled = true;
    }
    
}
