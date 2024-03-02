using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class CameraSystem : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Camera cam5;
    public Camera cam6;
    public Camera cam7;
    public GameObject Battery;


    public Camera PlayerCam;

    public GameObject Maxi;

    public GameObject CamPanel;
    
    public GameObject Player;

    List<Camera> AllCameras = new List<Camera>();
    public bool CamOn = false;
    
    void Start(){
   
        AllCameras.Add(cam1);
        AllCameras.Add(cam2);
        AllCameras.Add(cam3);
        AllCameras.Add(cam4);
        AllCameras.Add(cam5);
        AllCameras.Add(cam6);
        AllCameras.Add(cam7);
        CamPanel.SetActive(false);

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
    Battery.GetComponent<BatteryControlHub>().CamerasOpen =  !Battery.GetComponent<BatteryControlHub>().CamerasOpen;
    

        if(CamOn == false){
            CamOn = true;
            SwapCamVariableChange();
            cam1.enabled = true;
            CamPanel.SetActive(true);
            Player.GetComponent<PlayerMovement>().enabled = false;
            Maxi.GetComponent<MaxiScript>().CamCount += 1;
        }else{
            CamOn = false;
            SwapToPlayerView();
            CamPanel.SetActive(false);
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

    public void SwapToPlayerView(){
         foreach(Camera cam in AllCameras){
             cam.enabled = false;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCam.enabled = true;
    }
    
}
