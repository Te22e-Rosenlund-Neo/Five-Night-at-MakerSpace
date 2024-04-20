using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    //Remembers night when leaving game
    //deathscenes are called from here, 
    //resets everything when trying to play again
    //changes ai difficulty depending on what night we are at
    //sets available snus
    //holds gameloop going, calls gameover, gamewin.
    [Header("Night-Checker")]
    public int night;
    public bool GameWin;
    string Key = "NightLoad";

    [Header("Difficulties Nights - Neo")]
    public GameObject Neo;
    public float Ntime;
    public int[] NeoNightDifficulties = new int[5];

    [Header("Difficulties Nights - Sam")]
    public GameObject Sam;
    public float Stime;
    public int[] SamNightDifficulties = new int[5];

    [Header("Difficulties Nights - Hugo")]
    public GameObject Hugo;
    public float Htime;
    public int[] HugoNightDifficulties = new int[5];

    [Header("Difficulties Night - Martin")]
    public GameObject Martin;
    public float[] MNightsTime = new float[5];

    [Header("Difficulties Night - Maxi")]
    public GameObject Maxi;
    public float[] MaxiNightsTime = new float[5];

    [Header("snus")]
    public List<ListInList> Snusar;
    
    bool reset = false;
    public bool ChangeCurrentNightStuff;
    
    void Start(){
        night = PlayerPrefs.GetInt(Key);
        ChangeCurrentNightStuff = true;
    }
    void Update(){
//if player wins, we increase which night they are at, saves it and loads win cutscene
        if(GameWin == true){
            night ++;
            PlayerPrefs.SetInt(Key, night);
            GameWin = false;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync(2);
        }
//if player loads a new night, we change the difficulties of AI on nights
        if(ChangeCurrentNightStuff == true){
            ChangeCurrentNightStuff = false;
            Neo.GetComponent<EnemyScript>().AI_Level = NeoNightDifficulties[night-1];
            Sam.GetComponent<EnemyScript>().AI_Level = SamNightDifficulties[night-1];
            Hugo.GetComponent<EnemyScript>().AI_Level = HugoNightDifficulties[night-1];
            Martin.GetComponent<MartinScript>().StartTime = MNightsTime[night-1];
            Maxi.GetComponent<MaxiScript>().maxtime = MaxiNightsTime[night-1];
//Disables all snus, and only activies necessary ones
            foreach(var list in Snusar){
                    foreach(GameObject snus in list.inside){
                        snus.SetActive(false);
                    }
                }
            foreach(GameObject Esnus in Snusar[night-1].inside){
                Esnus.SetActive(true);
            }
            
            
        }

    }}
//class which allows me to display a list inside a list in the inspector
[Serializable]
public class ListInList{
    public List<GameObject> inside;
}