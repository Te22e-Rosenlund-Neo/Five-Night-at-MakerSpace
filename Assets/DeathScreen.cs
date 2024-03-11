using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    public GameObject AlphaShift;
    public TMP_Text text;
    public bool triggered;
    float alpha = 0;
    void Start(){
        text.enabled = false;
    }
    void Update(){
        if(triggered == true){
            text.enabled = true;
            AlphaShift.GetComponent<Image>().color = new Color(0,0,0,alpha);
            alpha += 0.001f;
        }
    }
}
