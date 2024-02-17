using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class BatteryControlHub : MonoBehaviour
{
    public int BatteryLevel = 1000;
    public bool CamerasOpen = false;
    public bool DoorClosed = false;
    public bool VentBlocked = false;
    public bool PassiveReduction = true;
    public int DefaultSpeed;
    
    public float timer = 1;
    private float timesincestart = 0;
    int Cam, DoorO, Vent;
    void Awake(){
        timesincestart = timer;
    }
    void Update(){
        if(CamerasOpen == true){
             Cam = 1;
        }else{
             Cam = 0;
        }
        if(DoorClosed == true){
             DoorO = 1;
        }else{
             DoorO = 0;
        }
        if(VentBlocked == true){
             Vent = 1;
        }else{
             Vent = 0;
        }
        int total = Cam + DoorO + Vent + DefaultSpeed;
        
        if(timesincestart <= 0){
            BatteryLevel -= total;
            timesincestart = timer;
        }
timesincestart -= Time.deltaTime;
    }


}
