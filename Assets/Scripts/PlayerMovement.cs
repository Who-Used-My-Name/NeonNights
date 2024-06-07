using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalIndput, verticalIndput;
    private float moveSpeed = 1.5f;
    public Animator animator;

    //Since this script is used in every scene for movement, this loads the player to their previous location and deletes the previous value when loaded.
    void Start(){
        float savedX = PlayerPrefs.GetFloat("playerPreviousX", 0f);
        float savedY = PlayerPrefs.GetFloat("playerPreviousY", 0f);
        if (savedX != 0f && savedY != 0f){
            transform.position = new Vector2(savedX, savedY);
        }
        else{
            PlayerPrefs.DeleteKey("playerPreviousX"); 
            PlayerPrefs.DeleteKey("playerPreviousY");
        }
    }

    //Player animation
    void Update(){
        horizontalIndput = Input.GetAxis("Horizontal");
        verticalIndput = Input.GetAxis("Vertical");
        string Animation;
         if (horizontalIndput > 0.1f){
            Animation = "WalkRight";
         }
         else if (horizontalIndput < -0.1f){
            Animation = "PlayerLeft";
         }
         else if (verticalIndput > 0.1f){
            Animation = "PlayerUp";
        }
        else if (verticalIndput < -0.1f){
            Animation = "PlayerDown";
        }
        else{
            Animation = "PlayerIdle";
        }
        animator.Play(Animation);
    }

    // Moves player at certain speed per frame update
    public void FixedUpdate(){
        transform.Translate(new Vector3(horizontalIndput, verticalIndput,0) * moveSpeed * Time.deltaTime);
    }

}
