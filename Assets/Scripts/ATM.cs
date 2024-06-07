using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATM : MonoBehaviour
{
    public int bankRoll;
    public bool ready = false;

    void Update(){
        if(Input.GetKeyDown(KeyCode.F) && ready == true){
            bankRoll = 2000;
            PlayerPrefs.SetInt("Bankroll",bankRoll);
        }
    }
                                                                    //If player presses F and is in range it will give them a balance of $2000
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            ready = true;
        }
        else
         ready = false;
    }
}
