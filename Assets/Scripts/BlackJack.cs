using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;


public class BlackJack : MonoBehaviour{

    public Dictionary<Sprite, int> cards = new Dictionary<Sprite, int>();
    public List<(Sprite sprite, int value)> playerHand = new List<(Sprite sprite, int value)>();
    public List<(Sprite sprite, int value)> dealerHand = new List<(Sprite sprite, int value)>();

    public bool playerTurn = true;
    public bool gameOver = false;
    public int betSize = 0;
    public int bankRoll;
    public int dealerHandValue = 0;
    public int playerHandValue = 0;

    public Button bet5;
    public Button bet10;
    public Button bet20;
    public Button bet50;
    public Button hit;
    public Button stand;
    public TextMeshProUGUI bankRollText;
    public TextMeshProUGUI currentBetText;
    public TextMeshProUGUI PlayerHandValue;
    public TextMeshProUGUI DealerHandValue;
    public Button exitButton;
    public Button deal;
    public bool blackJack = false;

    //Make buttons functional, Update in game UI, Add values to sprites at start of game
    void Start(){
        gameOver = true;
        deal.onClick.AddListener(NewHand);
        bankRoll = PlayerPrefs.GetInt("Bankroll");
        CreateDeck();
        UpdateBankRollText();
        UpdateCurrentBetText();
        hit.onClick.AddListener(() => Hit());
        stand.onClick.AddListener(() => Stand());
        bet5.onClick.AddListener(() => Bet5());
        bet10.onClick.AddListener(() => Bet10());
        bet20.onClick.AddListener(() => Bet20());
        bet50.onClick.AddListener(() => Bet50());
        bet5.interactable = true;
        bet10.interactable = true;
        bet20.interactable = true;
        bet50.interactable = true;
        exitButton.onClick.AddListener(Exit);
    }

    //Load previous scene
    void Exit(){
        SceneManager.LoadSceneAsync(2);
    }

    //Saves player money
    void SaveGame(){
        PlayerPrefs.SetInt("Bankroll", bankRoll);
    }

    void NewHand() {
            playerHand.Clear();
            dealerHand.Clear();
            DealInitialCards();
            UpdateBankRollText();
            UpdateCurrentBetText();
            UpdateCardSprites();
            playerTurn = true;
            gameOver = false;
            DealerHandValue.SetText("" + dealerHandValue);
            // GameObject PlayerStartCard1 = GameObject.Find("PlayerCards/PlayerStartCard1");
            // GameObject PlayerStartCard2 = GameObject.Find("PlayerCards/PlayerStartCard2");
            // PlayerStartCard1.GetComponent<SpriteRenderer>().sprite = playerHand[0].sprite;
            // PlayerStartCard2.GetComponent<SpriteRenderer>().sprite = playerHand[1].sprite;
            // GameObject DealerStartCard1 = GameObject.Find("DealerCards/DealerStartCard1");
            // DealerStartCard1.GetComponent<SpriteRenderer>().sprite = dealerHand[0].sprite;
            // Sprite FaceDownCard = Resources.Load<Sprite>("FaceDownTestCard");
            // PlayerStartCard2.GetComponent<SpriteRenderer>().sprite = FaceDownCard;
            bet5.interactable = false;
            bet10.interactable = false;
            bet20.interactable = false;
            bet50.interactable = false;

        }

    void CreateDeck(){
        cards.Add(Resources.Load<Sprite>("2club"), 2);
        cards.Add(Resources.Load<Sprite>("2heart"), 2);
        cards.Add(Resources.Load<Sprite>("2spade"), 2);
        cards.Add(Resources.Load<Sprite>("2diamond"), 2);
        cards.Add(Resources.Load<Sprite>("3spades"), 3);
        cards.Add(Resources.Load<Sprite>("3clubs"), 3);
        cards.Add(Resources.Load<Sprite>("3heart"), 3);
        cards.Add(Resources.Load<Sprite>("3diamond"), 3);
        cards.Add(Resources.Load<Sprite>("4spades"), 4);
        cards.Add(Resources.Load<Sprite>("4clubs"), 4);
        cards.Add(Resources.Load<Sprite>("4heart"), 4);
        cards.Add(Resources.Load<Sprite>("4diamond"), 4);
        cards.Add(Resources.Load<Sprite>("5spades"), 5);
        cards.Add(Resources.Load<Sprite>("5clubs"), 5);
        cards.Add(Resources.Load<Sprite>("5heart"), 5);
        cards.Add(Resources.Load<Sprite>("5diamond"), 5);
        cards.Add(Resources.Load<Sprite>("6spades"), 6);
        cards.Add(Resources.Load<Sprite>("6clubs"), 6);
        cards.Add(Resources.Load<Sprite>("6heart"), 6);
        cards.Add(Resources.Load<Sprite>("6diamond"), 6);
        cards.Add(Resources.Load<Sprite>("7spades"), 7);
        cards.Add(Resources.Load<Sprite>("7clubs"), 7);
        cards.Add(Resources.Load<Sprite>("7heart"), 7);
        cards.Add(Resources.Load<Sprite>("7diamond"), 7);
        cards.Add(Resources.Load<Sprite>("8spades"), 8);
        cards.Add(Resources.Load<Sprite>("8clubs"), 8);
        cards.Add(Resources.Load<Sprite>("8heart"), 8);
        cards.Add(Resources.Load<Sprite>("8diamond"), 8);
        cards.Add(Resources.Load<Sprite>("9spades"), 9);
        cards.Add(Resources.Load<Sprite>("9clubs"), 9);
        cards.Add(Resources.Load<Sprite>("9heart"), 9);
        cards.Add(Resources.Load<Sprite>("9diamond"), 9);
        cards.Add(Resources.Load<Sprite>("10spades"), 10);//10
        cards.Add(Resources.Load<Sprite>("10clubs"), 10);//10
        cards.Add(Resources.Load<Sprite>("10heart"), 10);//10
        cards.Add(Resources.Load<Sprite>("10diamond"), 10);//10
        cards.Add(Resources.Load<Sprite>("Jspades"), 10);//JACK
        cards.Add(Resources.Load<Sprite>("Jclubs"), 10);//JACK
        cards.Add(Resources.Load<Sprite>("Jheart"), 10);//JACK
        cards.Add(Resources.Load<Sprite>("Jdiamond"), 10);//JACK
        cards.Add(Resources.Load<Sprite>("Qspades"), 10);//QUEEN
        cards.Add(Resources.Load<Sprite>("Qclubs"), 10);//QUEEN
        cards.Add(Resources.Load<Sprite>("Qheart"), 10);//QUEEN
        cards.Add(Resources.Load<Sprite>("Qdiamond"), 10);//QUEEN
        cards.Add(Resources.Load<Sprite>("Kspades"), 10);//KING
        cards.Add(Resources.Load<Sprite>("Kclubs"), 10);//KING
        cards.Add(Resources.Load<Sprite>("Kheart"), 10);//KING
        cards.Add(Resources.Load<Sprite>("Kdiamond"), 10);//KING
        cards.Add(Resources.Load<Sprite>("Aspades"), 11);//ACE
        cards.Add(Resources.Load<Sprite>("Aclubs"), 11);//ACE
        cards.Add(Resources.Load<Sprite>("Aheart"), 11);//ACE
        cards.Add(Resources.Load<Sprite>("Adiamond"), 11);//ACE
    }

    void DealInitialCards(){
        playerHand.Clear();
        dealerHand.Clear();
         for (int i = 0; i < 2; i++){
            int random = Random.Range(0, cards.Count);
            Sprite Sprite = cards.ElementAt(random).Key;
            int value = cards[Sprite];
            playerHand.Add((Sprite, value));
            playerHandValue=CalculateHandValue(playerHand);
            PlayerHandValue.SetText("" + playerHandValue);
        }
        for (int i = 0; i < 2; i++){
            int random = Random.Range(0, cards.Count);
            Sprite randomSprite = cards.ElementAt(random).Key;
            int randomValue = cards[randomSprite];
            dealerHand.Add((randomSprite, randomValue));
        }
        CheckForBlackjack();
    }

    // Shows sprites when dealt cards
    void UpdateCardSprites(){
        GameObject PlayerStartCard1 = GameObject.Find("PlayerCards/PlayerStartCard1");
        GameObject PlayerStartCard2 = GameObject.Find("PlayerCards/PlayerStartCard2");
        PlayerStartCard1.GetComponent<SpriteRenderer>().sprite = playerHand[0].sprite;
        PlayerStartCard2.GetComponent<SpriteRenderer>().sprite = playerHand[1].sprite;
        GameObject DealerStartCard1 = GameObject.Find("DealerCards/DealerStartCard1");
        DealerStartCard1.GetComponent<SpriteRenderer>().sprite = dealerHand[0].sprite;

        Sprite faceDown = Resources.Load<Sprite>("faceDownTestCard");
        GameObject DealerStartCard2 = GameObject.Find("DealerCards/DealerStartCard2");
        DealerStartCard2.GetComponent<SpriteRenderer>().sprite = faceDown;
        PlayerHandValue.SetText("" + playerHandValue);
    }

    void RevealDealerCard(){
        GameObject DealerStartCard2 = GameObject.Find("DealerCards/DealerStartCard2");
        DealerStartCard2.GetComponent<SpriteRenderer>().sprite = dealerHand[1].sprite;
        playerTurn=true;
        dealerHandValue = CalculateHandValue(dealerHand);
        DealerHandValue.SetText(""+ dealerHandValue);
    }


    void UpdateBankRollText(){
        bankRollText.text = "Bank Roll: " + bankRoll.ToString();
    }

    void UpdateCurrentBetText(){
        currentBetText.text = "Current Bet: " + betSize.ToString();
    }

    int CalculateHandValue(List<(Sprite sprite, int value)> hand){
        int totalValue = 0;

        foreach (var (sprite, value) in hand){
            totalValue += value;
        }
        if(hand.Count > 0 && hand[0].value==11 && totalValue > 21){
            totalValue -= 10;
        }

        return totalValue;
    }

    //Called right after new hand dealt
    void CheckForBlackjack(){
        if(CalculateHandValue(playerHand)==21){
            gameOver=true;
            blackJack = true;
            EndGame();

        }
        else if( CalculateHandValue(dealerHand)==21){
            bankRoll -= betSize *3;
            gameOver=true;
            blackJack = true;
            EndGame();
        }
    }

    //Called after every "hit"
    void CheckForBust(){
        if(CalculateHandValue(playerHand)>21){
            gameOver=true;
            EndGame();
        }
    }

    void CheckForPush(){
        int playerHandValue = CalculateHandValue(playerHand);
        int dealerHandValue = CalculateHandValue(dealerHand);

        if (playerHandValue ==  dealerHandValue ){
            bankRoll += betSize;
            UpdateBankRollText();

        }
    }

    void CheckForWin(){

        int playerHandValue = CalculateHandValue(playerHand);
        int dealerHandValue = CalculateHandValue(dealerHand);
        if(blackJack==true){
            bankRoll += betSize * 3;
            blackJack = false;
            UpdateBankRollText();
        }
        else if (playerHandValue > 21 || (dealerHandValue <= 21 && dealerHandValue > playerHandValue)){
            bankRoll +=0;
        }
        else if ((playerHandValue <= 21 && dealerHandValue >21) || (playerHandValue >=21 && playerHandValue>dealerHandValue)){
            bankRoll += betSize *2;
        }
    }


    //Called after "standing" and dealer's logic
    void EndGame(){
        if(gameOver){
            RevealDealerCard();
            // if(playerHandValue> 21){
            //     CheckForWin();
            // }
            while(dealerHandValue<17 || dealerHandValue<playerHandValue && playerHandValue<=21){
                DealNewCard(dealerHand);
                dealerHandValue = CalculateHandValue(dealerHand);
                DealerHandValue.SetText("" + dealerHandValue);
                break;
            }

            CheckForWin();
            CheckForPush();
            dealerHand.Clear();
            playerHand.Clear();
            gameOver = false;
            betSize = 0;
            UpdateBankRollText();
            UpdateCurrentBetText();
            SaveGame();
            playerTurn=true;
            dealerHandValue=0;
            bet5.interactable = true;
            bet10.interactable = true;
            bet20.interactable = true;
            bet50.interactable = true;

        }
    }


    public void Hit(){
        DealNewCard(playerHand);
        playerHandValue = CalculateHandValue(playerHand);
        CheckForBust();
        PlayerHandValue.SetText("" + playerHandValue);
    }

    //Buttons are interactable again and game is ready for new round
    public void Stand(){
        playerTurn=false;
        gameOver=true;
        bet5.interactable = true;
        bet10.interactable = true;
        bet20.interactable = true;
        bet50.interactable = true;
        EndGame();
    }

    public void DealNewCard(List<(Sprite sprite, int value)> hand){
        int random = Random.Range(0, cards.Count);
        Sprite Sprite = cards.ElementAt(random).Key;
        int value = cards[Sprite];
        hand.Add((Sprite, value));
    }

    public void Bet5(){
        betSize+=5;
        bankRoll-=5;
        UpdateBankRollText();
        UpdateCurrentBetText();
    }
    public void Bet10(){
        betSize+=10;
        bankRoll-=10;
        UpdateBankRollText();
        UpdateCurrentBetText();

    }
    public void Bet20(){
        betSize+=20;
        bankRoll-=20;
        UpdateBankRollText();
        UpdateCurrentBetText();
    }
    public void Bet50(){

        betSize+=50;
        bankRoll-=50;
        UpdateBankRollText();
        UpdateCurrentBetText();
    }

        //Makes buttons uninteractable if player does not have the money for it
        void Update(){
        if(betSize==0){
            deal.interactable = false;
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
            deal.interactable = true;
        }
        
        if (!gameOver){
            if (playerTurn==true){
                playerHandValue=CalculateHandValue(playerHand);
            }
            else{
                gameOver=true;
                EndGame();
            }
        }
    }


}