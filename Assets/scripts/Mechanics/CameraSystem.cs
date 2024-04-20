using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class CameraSystem : MonoBehaviour
{
    public Camera cam1, cam2, cam3, cam4, cam5, cam6, cam7;
    public GameObject Battery;


    public Camera PlayerCam;

    public GameObject Maxi;

    public GameObject CamPanel;
    
    public GameObject Player;

    List<Camera> AllCameras = new List<Camera>();
    public bool CamOn = false;
    
    void Start(){
   //adds all cameras to list, and sets camera on to be false
        AllCameras.Add(cam1);
        AllCameras.Add(cam2);
        AllCameras.Add(cam3);
        AllCameras.Add(cam4);
        AllCameras.Add(cam5);
        AllCameras.Add(cam6);
        AllCameras.Add(cam7);
        CamPanel.SetActive(false);
//disables all cameras as default and enables players
        foreach(Camera cam in AllCameras){
            cam.enabled = false;
        }
        AllCameras.Add(PlayerCam);
    }
    void Update(){
//if space is pressed, we open or close the camera
        if(Input.GetKeyDown(KeyCode.Space)){
            ToggleCam();
        }
    }
    

    public void ToggleCam(){
    Battery.GetComponent<BatteryControlHub>().CamerasOpen =  !Battery.GetComponent<BatteryControlHub>().CamerasOpen;
    

        if(CamOn == false){
        //disables players main camera and movement script, and shows the new camera view
            CamOn = true;
            SwapCamVariableChange();
            cam1.enabled = true;
            CamPanel.SetActive(true);
            Player.GetComponent<PlayerMovement>().enabled = false;
            Maxi.GetComponent<MaxiScript>().CamCount += 1;
        }else{
        //disables all camera view, enables player movement and camera
            CamOn = false;
            SwapToPlayerView();
            CamPanel.SetActive(false);
            Player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
    void SwapCamVariableChange(){
    //disables all cameras, and shows a cursor
        foreach (Camera cam in AllCameras){
            cam.enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SwitchCam(int Camera){
    //when player interacts with camera ui, it changes what the player sees
    //and the camera that is pressed is shown
        SwapCamVariableChange();
        AllCameras[Camera].enabled = true;
    }

    public void SwapToPlayerView(){
    //disables all other cameras, shows player cam and locks cursor. 
         foreach(Camera cam in AllCameras){
             cam.enabled = false;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCam.enabled = true;
    }
    
}
