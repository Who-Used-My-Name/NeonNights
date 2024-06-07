using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plinko : MonoBehaviour
{
    public int bankRoll;
    public int betSize = 100;
    public int win = 0;
    private bool dropped = false;
    public Rigidbody2D ball;
    public Transform leftLimit;
    public Transform rightLimit;
    public Collider2D Mult_5;
    public Collider2D Mult_0;
    public Collider2D Mult_0v2;
    public Collider2D Mult_50;
    public Collider2D Mult_50v2;
    public Collider2D Mult_1DOT1;
    public Collider2D Mult_DOT2;
    public Collider2D Mult_20;
    public Collider2D Mult_1;
    public Collider2D Mult_DOT1;
    public Collider2D Mult_10;
    public Collider2D Mult_DOT8;
    public Collider2D Mult_1DOT5;
    public TextMeshProUGUI bankRollText;
    public TextMeshProUGUI currentBetText;
    public Button exitButton;

    // Payouts for each different "Pocket" based on collision with its hitbox. Saves players money. Updates UI. Restarts the game when done.
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("5")){
            win = betSize * 5;
            bankRoll-= betSize;
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag("0")){
            win = betSize * 0;
            bankRoll-= betSize;
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag("50")){
            win = betSize * 50;
            bankRoll-= betSize;
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag("1.1")){
            bankRoll-= betSize;
            win = (int)(betSize * 1.1);
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag(".2")){
            bankRoll-= betSize;
            win = (int)(betSize * .2);
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag("20")){
            bankRoll-= betSize;
            win = betSize * 20;
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag("1")){
            bankRoll-= betSize;
            win = betSize * 1;
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag(".8")){
            bankRoll-= betSize;
            win = (int)(betSize * .8);
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag(".1")){
            bankRoll-= betSize;
            win = (int)(betSize * .1);
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag("10")){
            bankRoll-= betSize;
            win = betSize * 10;
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag(".5")){
            bankRoll-= betSize;
            win = (int)(betSize * .5);
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
        if(other.CompareTag("1.5")){
            bankRoll-= betSize;
            win = (int)(betSize * 1.5);
            bankRoll += win;
            SaveGame();
            UpdateBankRollText();
            ResetGame();
        }
    }

        //UPDATES THE PLAYERS BANK ROLL UI AS THEY WIN/LOSE
    void UpdateBankRollText(){
        bankRollText.SetText("Bank Roll: " + PlayerPrefs.GetInt("Bankroll"));
    }
        //UPDATES THE BET AMOUNT UI FOR EACH ROUND
    void UpdateCurrentBetText(){
        currentBetText.SetText("Current Bet: " + betSize.ToString());
    }

    void SaveGame(){
        PlayerPrefs.SetInt("Bankroll", bankRoll);
    }

        //LEAVE GAME AND RETURN TO CASINO
    void Exit(){
        SceneManager.LoadSceneAsync(5);
        //StartCoroutine(LoadingScene());
    }

        // Start is called before the first frame update
    void Start()
    {
        UpdateBankRollText();
        UpdateCurrentBetText();
        exitButton.onClick.AddListener(Exit);
        bankRoll = PlayerPrefs.GetInt("Bankroll", bankRoll);

    }

        // Move ball and drop when enter is pressed. 
    void Update(){
        if (!dropped)
        {
            // MOVE BALL
            float horizontalInput = Input.GetAxis("Horizontal");
            float newPositionX = Mathf.Clamp(ball.position.x + horizontalInput *.04f, leftLimit.position.x, rightLimit.position.x);
            ball.MovePosition(new Vector2(newPositionX, ball.position.y));

            // DROP BALL
            if (Input.GetKeyDown(KeyCode.Return))
            {
                dropped = true;
                ball.gravityScale = .6f; 
            }
        }
    }

    //Puts ball at top after round is over.
    void ResetGame(){
        dropped = false;
        ball.position = new Vector2(13.096f, 7.983f);
        ball.gravityScale = 0f;
    }

    // IEnumerator LoadingScene(){
    // yield return new WaitForSeconds(5f);  Was experimenting with the idea of a "Loading Screen" but couldn't get it to work.
    // SceneManager.LoadSceneAsync(7);
    // }

}
