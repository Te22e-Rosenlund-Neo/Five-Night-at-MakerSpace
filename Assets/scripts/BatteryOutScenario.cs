using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScenario : MonoBehaviour
{
   public GameObject ChangeCam;
   public GameObject Player;

    public void ShutOff(){
        ChangeCam.SetActive(false);
        Player.SetActive(false);

    }
}
