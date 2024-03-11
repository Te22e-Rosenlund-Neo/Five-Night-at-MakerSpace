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

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
}
