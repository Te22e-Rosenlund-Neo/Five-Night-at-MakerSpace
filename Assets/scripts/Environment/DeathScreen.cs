using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{
    public GameObject AlphaShift;
    public TMP_Text text;
    public bool triggered;
    float alpha = 0;
    float Timer = 8f;
    void Start(){
        text.enabled = false;
    }
//slowly transitions into a black screen with only text
    void Update(){
        if(triggered == true){
            text.enabled = true;
            AlphaShift.GetComponent<Image>().color = new Color(0,0,0,alpha);
            alpha += 0.001f;
            Timer -= Time.deltaTime;
            if(Timer <= 0){
                SceneManager.LoadSceneAsync(0);
            }
        }
    }
}
