using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.UIElements.Experimental;
using Unity.Mathematics;
using System;

public class BatteryControlHub : MonoBehaviour
{
    public float BatteryLevel = 1000;

    public bool CamerasOpen = false;
    public bool DoorClosed = false;
    public bool VentBlocked = false;
    public bool PassiveReduction = true;
    public int DefaultSpeed;

    public TMP_Text BatteryDisplayText;
    public TMP_Text TimeText;

//max time is 360s
    public float ClockTime = 0;
    
    public float timer = 1;
    private float timesincestart = 0;
    int Cam, DoorO, Vent;
    void Awake(){
        timesincestart = timer;
    }
    void Update(){
     DisplayBattery();
     DisplayTime();
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

          if(BatteryLevel <= 0){
               GetComponent<GameOverScenario>().ShutOff();
          }
          if(ClockTime >= 360){
               GameObject.Find("GameManager").GetComponent<GameManagerScript>().GameWin = true;
          }
ClockTime += Time.deltaTime;
    }

    void DisplayBattery(){
          int value = Mathf.RoundToInt(BatteryLevel*0.1f);
          BatteryDisplayText.text = value + "%";
    }
    void DisplayTime(){
     float newvalue = Mathf.Floor(ClockTime/60);
          TimeText.text = newvalue + "AM";
    }


}
