using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScenario : MonoBehaviour
{
   public GameObject ChangeCam;
   public GameObject Player;

   public GameObject BalloonBoy;

//triggers death scene if batery is 0
    public void ShutOff(){
        ChangeCam.SetActive(false);
        Player.SetActive(false);
        BalloonBoy.GetComponent<BalloonBoyDeathSequence>().start = true;
    }
}
