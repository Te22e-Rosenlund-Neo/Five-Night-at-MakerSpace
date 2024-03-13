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
    //acts as a middleground, deathscenes are called from here, 
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
    public TMP_Text text;
    

    void Awake(){
        DontDestroyOnLoad(gameObject);
        
        
    }
    void Update(){
        // if(SceneManager.GetActiveScene() == SceneManager.GetSceneAt(0)){
        //    text.GetComponent<TextMeshProUGUI>().text = "Night - " + PlayerPrefs.GetInt(Key);
        // }

        if(GameWin == true){
            night ++;
            PlayerPrefs.SetInt(Key, night);
            GameWin = false;
            SceneManager.LoadSceneAsync(2);

        }

        if(reset == true){
            reset = false;
            night = 1;
        }
        if(ChangeCurrentNightStuff == true){
            ChangeCurrentNightStuff = false;
            Neo.GetComponent<EnemyScript>().AI_Level = NeoNightDifficulties[night-1];
            Sam.GetComponent<EnemyScript>().AI_Level = SamNightDifficulties[night-1];
            Hugo.GetComponent<EnemyScript>().AI_Level = HugoNightDifficulties[night-1];
            Martin.GetComponent<MartinScript>().StartTime = MNightsTime[night-1];
            Maxi.GetComponent<MaxiScript>().maxtime = MaxiNightsTime[night-1];
            foreach(var list in Snusar){
                    foreach(GameObject snus in list.inside){
                        snus.SetActive(false);
                    }
                }
            foreach(GameObject Esnus in Snusar[night-1].inside){
                Esnus.SetActive(true);
            }
            
            
        }

    }
    public void NewGame(){
        reset = true;
        ChangeCurrentNightStuff = true;
        SceneManager.LoadScene(1);
    }
    public void Continue(){
        night = PlayerPrefs.GetInt(Key);
        ChangeCurrentNightStuff = true;
        SceneManager.LoadScene(1);
    }
}
[Serializable]
public class ListInList{
    public List<GameObject> inside;
}