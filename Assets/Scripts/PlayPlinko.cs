using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayPlinko : MonoBehaviour
{

    public bool ready = false;
    public GameObject Player;
    private Vector2 playerPosition;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.F) && ready == true){
            playerPosition = Player.transform.position;
            PlayerPrefs.SetFloat("playerPreviousX", playerPosition.x);
            PlayerPrefs.SetFloat("playerPreviousY", playerPosition.y);

            SceneManager.LoadScene(4);
        }
    }
                                                                        //If player presses F and is in range it will load plinko game while saving their previous location
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            playerPosition = Player.transform.position;
            PlayerPrefs.SetFloat("playerPreviousX", playerPosition.x);
            PlayerPrefs.SetFloat("playerPreviousY", playerPosition.y);
            ready = true;
        }
        else
         ready = false;
    }

    public Vector2 GetPlayerLocation(){
        return playerPosition;
    }
}
