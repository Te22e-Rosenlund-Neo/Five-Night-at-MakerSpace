using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    string Key = "NightLoad";
    public TMP_Text NightOutput;
    void Start()
    {
//displays which night that can be continued
        NightOutput.text = "Night - " + PlayerPrefs.GetInt(Key).ToString();
    }

    
    public void NewGame(){
//resets night in save file
        PlayerPrefs.SetInt(Key, 1);
        SceneManager.LoadScene(1);
    }
    public void Continue(){
//continues night from last played time
        SceneManager.LoadScene(1);
    }
    public void Quit(){
//exits application
        Application.Quit();
}
}
