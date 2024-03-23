using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class NightText : MonoBehaviour
{
    string Key = "NightLoad";
    public TMP_Text NightOutput;
    void Start()
    {
        NightOutput.text = "Night - " + PlayerPrefs.GetInt(Key).ToString();
    }
    
    public void NewGame(){
        PlayerPrefs.SetInt(Key, 1);
        SceneManager.LoadScene(1);
    }
    public void Continue(){
        SceneManager.LoadScene(1);
    }
    public void Quit(){
        Application.Quit();
}
}
