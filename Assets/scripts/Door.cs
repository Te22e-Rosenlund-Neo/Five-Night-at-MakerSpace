using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    public bool DoorOpen = false;
    [SerializeField] float timeToOpen;
    [Header("2 Door Positions")]
    [SerializeField] Vector3 Top;
    [SerializeField] Vector3 Bottom;
    float time = 0;
    
    public AudioClip Close;
    public GameObject ChangeAudio;
    public List<GameObject> ConditionalPoints;
  
    void FixedUpdate(){
        if(time < timeToOpen){
            if(DoorOpen == false){
                transform.position = Vector3.Lerp(Bottom, Top, time/timeToOpen);

            }else{
                transform.position = Vector3.Lerp(Top, Bottom, time/timeToOpen);
                
            }
            time += Time.deltaTime;
        }
      

    
}
public void ToggleDoor()
    {
     time = 0;
     if(DoorOpen == false){
        DoorOpen = true;
        ChangeAudio.GetComponent<NouseAudioSc>().NoiseChange(Close);
     }else{
        DoorOpen = false;
    }
    foreach(GameObject point in ConditionalPoints){
        point.GetComponent<PointsAcessiible>().Accessible = !point.GetComponent<PointsAcessiible>().Accessible;
    }
}
}















