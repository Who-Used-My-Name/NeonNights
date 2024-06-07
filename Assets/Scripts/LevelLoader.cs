using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour{
 
    public GameObject player;

    public float ElevatorDownX = 64.3669f;
    public float ElevatorDownY = 36.7177f;
    public float OutsideX = -0.1533876f;
    public float OutsideY = 0.4277888f;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Exit Casino")){
            PlayerPrefs.SetFloat("playerPreviousX",OutsideX);
            PlayerPrefs.SetFloat("playerPreviousY",OutsideY);
            SceneManager.LoadSceneAsync(1,LoadSceneMode.Single);
        }
        if(other.gameObject.CompareTag("EnterCasino")){
            SceneManager.LoadSceneAsync(2,LoadSceneMode.Single);
            PlayerPrefs.SetFloat("playerPreviousX",64.39f);
            PlayerPrefs.SetFloat("playerPreviousY",33.993f);
        }
        if(other.gameObject.CompareTag("FirstElevator")){
            SceneManager.LoadSceneAsync(5,LoadSceneMode.Single);
            PlayerPrefs.SetFloat("playerPreviousX",0.257f);
            PlayerPrefs.SetFloat("playerPreviousY",1.449f);
        }
        if(other.gameObject.CompareTag("ElevatorDown")){
            SceneManager.LoadSceneAsync(2,LoadSceneMode.Single);
            PlayerPrefs.SetFloat("playerPreviousX",ElevatorDownX);
            PlayerPrefs.SetFloat("playerPreviousY",ElevatorDownY);
        }
    }


}


