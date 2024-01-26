using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class test : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Camera cam5;
    public Camera cam6;
    public Camera cam7;


    public Camera PlayerCam;
    public Canvas canvas;
    public GameObject Player;

    List<Camera> AllCameras = new List<Camera>();
    private bool CamOn = false;
    
    void Start(){
   
        AllCameras.Add(cam1);
        AllCameras.Add(cam2);
        AllCameras.Add(cam3);
        AllCameras.Add(cam4);
        AllCameras.Add(cam5);
        AllCameras.Add(cam6);
        AllCameras.Add(cam7);
        canvas.enabled = false;

        foreach(Camera cam in AllCameras){
            cam.enabled = false;
        }
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
            SwapCamVariableChange();
            cam1.enabled = true;
            canvas.enabled = true;
            Player.GetComponent<PlayerMovement>().enabled = false;
        }else{
            CamOn = false;
            SwapToPlayerView();
            canvas.enabled = false;
            Player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
    void SwapCamVariableChange(){
        foreach (Camera cam in AllCameras){
            cam.enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SwitchCam(int Camera){
        SwapCamVariableChange();
        AllCameras[Camera].enabled = true;
    }
    // public void SwitchCam1(){

    //     SwapCamVariableChange();
    //     cam1.enabled = true;
    // }
    // public void SwitchCam2(){

    //     SwapCamVariableChange();
    //     cam2.enabled = true;
    // }
    // public void SwitchCam3(){

    //     SwapCamVariableChange();
    //     cam3.enabled = true;
    // }
    // public void SwitchCam4(){

    //     SwapCamVariableChange();
    //     cam4.enabled = true;
    // }
    // public void SwitchCam5(){

    //     SwapCamVariableChange();
    //     cam5.enabled = true;
    // }
    // public void SwitchCam6(){

    //     SwapCamVariableChange();
    //     cam6.enabled = true;
    // }
    // public void SwitchCam7(){

    //     SwapCamVariableChange();
    //     cam7.enabled = true;
    // }

    public void SwapToPlayerView(){
         foreach(Camera cam in AllCameras){
             cam.enabled = false;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCam.enabled = true;
    }
    
}
