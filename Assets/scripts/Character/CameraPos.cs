using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
  
  public Transform cameraPosition;

  private void Update(){
//makes camera follow player
    transform.position = cameraPosition.position;
  }
}
