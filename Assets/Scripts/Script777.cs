using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random=UnityEngine.Random;
public class Script777 : MonoBehaviour{

    public Button bet5;
    public Button bet10;
    public Button bet20;
    public Button bet50;
    public TextMeshProUGUI bankRollText;
    public TextMeshProUGUI currentBetText;
    public Button exitButton;
    public Button spin;
    public Button clearBet;
    public int betSize = 0;
    public int bankRoll;
    public Sprite[] slotSprites; 
    public Image[] slotColumns;

    // Start is called before the first frame update
    void Start(){
        UpdateBankRollText();
        UpdateCurrentBetText();
        bankRoll = PlayerPrefs.GetInt("Bankroll");
        exitButton.onClick.AddListener(Exit);
        spin.onClick.AddListener(() => Spin());
        clearBet.onClick.AddListener(() => ClearBet());
        bet5.onClick.AddListener(() => Bet5());
        bet10.onClick.AddListener(() => Bet10());
        bet20.onClick.AddListener(() => Bet20());
        bet50.onClick.AddListener(() => Bet50());
        bankRollText.SetText("Bankroll: $"+bankRoll);
    }

    //Player can't bet more than their bankroll allows and if the bet is 0 then they can not spin the machine.
    void Update(){
        UpdateCurrentBetText();
        PlayerPrefs.SetInt("Bankroll",bankRoll);
        if(bankRoll ==0 && betSize ==0){
            spin.interactable=false;
        }
        if(betSize==0){
            spin.interactable = false;
        }
        if(bankRoll<50){
            bet50.interactable = false;
        }
        if(bankRoll<20){
            bet20.interactable = false;
        }
        if(bankRoll<10){
            bet10.interactable = false;
        }
        if(bankRoll<5){
            bet5.interactable = false;
        }

        else{
            spin.interactable = true;
        }
    }
    


    void UpdateBankRollText(){
        bankRollText.text = "Bank Roll: $" + bankRoll.ToString();
    }
    //UPDATES THE BET AMOUNT UI FOR EACH ROUND
    void UpdateCurrentBetText(){
        currentBetText.text = "Current Bet: $" + betSize.ToString();
    }

    void Exit(){
        SceneManager.LoadSceneAsync(5);
    }

    //Updates UI as bets placed
    public void Bet5(){
        if(bankRoll >= 5){
            betSize+=5;
            bankRoll-=5;
            UpdateBankRollText();
            UpdateCurrentBetText();
            SaveGame();
        }
        else{
            Console.Write("Not Enough Money.");
        }
    }
    public void Bet10(){
        if(bankRoll >= 10){
        betSize+=10;
        bankRoll-=10;
        UpdateBankRollText();
        UpdateCurrentBetText();
        SaveGame();
        }
        else{
            Console.Write("Not Enough Money.");
        }
    }
    public void Bet20(){
        if(bankRoll >= 20){
        betSize+=20;
        bankRoll-=20;
        UpdateBankRollText();
        UpdateCurrentBetText();
        SaveGame();
        }
        else{
            Console.Write("Not Enough Money.");
        }
    }
    public void Bet50(){
        if(bankRoll >= 50){
        betSize+=50;
        bankRoll-=50;
        UpdateBankRollText();
        UpdateCurrentBetText();
        SaveGame();
        }
        else{
            Console.Write("Not Enough Money.");
        }
    }

    void SaveGame(){
        PlayerPrefs.SetInt("Bankroll", bankRoll);
    }
    public void ClearBet(){
        bankRoll+=betSize;
        betSize=0;
    }

    //Find 3 random sprites/symbols
    public void Spin(){
        for (int i = 0; i < slotColumns.Length; i++) { 
            int random = Random.Range(0, slotSprites.Length);
            slotColumns[i].sprite = slotSprites[random];
        }
        //bankRoll -= betSize;
        CalculatePayout();
    }

    //Payout amount & win conditions
    public void CalculatePayout() {
        Sprite col1 = slotColumns[0].sprite;
        Sprite col2 = slotColumns[1].sprite;
        Sprite col3 = slotColumns[2].sprite;

        if (col1 == col2 && col2 == col3) {
            bankRoll += betSize * 2;
            SaveGame();
        } 
        else if (col1 == col2 || col2 == col3) {
            bankRoll += betSize;
            SaveGame();
        }
        if(bankRoll-betSize<0){
            bankRoll=0;
        }
        else {
            SaveGame();
        }
        UpdateBankRollText();
    }


}
