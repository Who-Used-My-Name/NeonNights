using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{

    public Button StartButton;
    public Vector2 playerPosition;
    public GameObject Player;

    // Loads player in front of casino at the start
    void Start(){
        StartButton.onClick.AddListener(StartGame);
        PlayerPrefs.SetFloat("playerPreviousX", -0.1735f);
        PlayerPrefs.SetFloat("playerPreviousY",-0.4618f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame(){
        SceneManager.LoadSceneAsync(1);
    }


}
