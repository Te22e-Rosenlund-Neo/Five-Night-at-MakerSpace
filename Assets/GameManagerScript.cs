using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int[] NNight1 = new int[3];
    public int[] NNight2 = new int[3];
    public int[] NNight3 = new int[3];
    public int[] NNight4 = new int[3];
    public int[] NNight5 = new int[3];
    [Header("Difficulties Nights - Sam")]
    public int[] SNight1 = new int[3];
    public int[] SNight2 = new int[3];
    public int[] SNight3 = new int[3];
    public int[] SNight4 = new int[3];
    public int[] SNight5 = new int[3];
    [Header("Difficulties Nights - Hugo")]
    public int[] HNight1 = new int[3];
    public int[] HNight2 = new int[3];
    public int[] HNight3 = new int[3];
    public int[] HNight4 = new int[3];
    public int[] HNight5 = new int[3];
    [Header("Difficulties Night - Martin")]
    public float[] MNightsTimes = new float[5];
    [Header("Difficulties Night - Maxi")]
    public float[] MaxiNightsTimes = new float[5];
    [Header("snus")]
    public List<GameObject> SnusNight1;
    public List<GameObject> SnusNight2;
    public List<GameObject> SnusNight3;
    public List<GameObject> SnusNight4;
    public List<GameObject> SnusNight5;

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    void Update(){
        if(GameWin == true){
            night ++;
            PlayerPrefs.SetInt(Key, night);
            GameWin = false;
        }
    }
}
