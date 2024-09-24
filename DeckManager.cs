using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;


public class DeckManager : MonoBehaviour
{
    // public GameObject cardPrefab;            // The generic card prefab to instantiate
    public List<Sprite> cardFaceSprites;    // List of all card front images (52 cards)
    public List<int> cardValues;             // List of corresponding card values (2-10, J=10, Q=10, K=10, A=1/11)
    private List<GameObject> deck;
    
    public List<Sprite> cardBackSprites;
    public CardSettings cardSettings;

    public Sprite backCard;           // The deck of cards in play

    public GameObject deckButton;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;
    public GameObject Card7;
    public GameObject Card8;
    public GameObject Card9;
    public GameObject Card10;

    public GameObject BustText;
    public GameObject WinText;
    public GameObject FiveCardText;
    public GameObject LoseText;

    public GameObject PushText;
    

    public List<GameObject> playerHand;
    public List<GameObject> dealerHand; 

    private int playerHandSize = 2;
    private int dealerHandSize = 2;

    private int playerTotal;

    private int dealerTotal;

    private int playerAceCount = 0;
    private int dealerAceCount = 0;

    private int playerHitCount = 0;


    private List<int> selectedIndices;
    public static DeckManager Instance { get; private set; }
    void Start()
    {
        int selectedCardBackIndex = PlayerPrefs.GetInt("SelectedCardBack", 0);
        backCard = cardBackSprites[selectedCardBackIndex];
        Debug.Log("Retrieved card back index: " + selectedCardBackIndex);
        UpdateCardBacks();
    }

    
    public void UpdateCardBacks()
    {
        if (deckButton != null)
        {
            deckButton.GetComponent<UnityEngine.UI.Image>().sprite = backCard;
            Debug.Log("Deck button back updated.");
        }

        Card1.GetComponent<SpriteRenderer>().sprite = backCard;
        Card2.GetComponent<SpriteRenderer>().sprite = backCard;
        Card3.GetComponent<SpriteRenderer>().sprite = backCard;
        Card4.GetComponent<SpriteRenderer>().sprite = backCard;
        Card5.GetComponent<SpriteRenderer>().sprite = backCard;
        Card6.GetComponent<SpriteRenderer>().sprite = backCard;
        Card7.GetComponent<SpriteRenderer>().sprite = backCard;
        Card8.GetComponent<SpriteRenderer>().sprite = backCard;
        Card9.GetComponent<SpriteRenderer>().sprite = backCard;
        Card10.GetComponent<SpriteRenderer>().sprite = backCard;

    }



    public void DealDeck()
    {
        InitializeDeck();                    // Initialize the deck when the game starts
    }
    void InitializeDeck()
    {   

        WinText.SetActive(false);
        LoseText.SetActive(false);
        BustText.SetActive(false);        
        FiveCardText.SetActive(false);
        PushText.SetActive(false);

        playerHand = new List<GameObject>();
        dealerHand = new List<GameObject>();
        playerHandSize = 2;
        dealerHandSize = 2;
        deck = new List<GameObject>{
            Card1, Card2, Card3, Card4, Card5, Card6, Card7, Card8, Card9, Card10 
        };
        playerHitCount = 0;
        playerTotal = 0; 
        dealerTotal= 0;
        playerAceCount = 0;
        dealerAceCount =0;
        
        Card1.GetComponent<Animator>().SetBool("DealCard1Bool", false);
        Card2.GetComponent<Animator>().SetBool("DealCard2Bool", false);
        Card3.GetComponent<Animator>().SetBool("DealCard3Bool", false);
        Card4.GetComponent<Animator>().SetBool("DealCard4Bool", false);
        Card5.GetComponent<Animator>().SetBool("DealCard5Bool", false);
        Card6.GetComponent<Animator>().SetBool("DealCard6Bool", false);
        Card7.GetComponent<Animator>().SetBool("DealCard7Bool", false);
        Card8.GetComponent<Animator>().SetBool("DealCard8Bool", false);
        Card9.GetComponent<Animator>().SetBool("DealCard9Bool", false);
        Card10.GetComponent<Animator>().SetBool("DealCard10Bool", false);

        //Backside
        Card1.GetComponent<SpriteRenderer>().sprite = backCard;
        Card2.GetComponent<SpriteRenderer>().sprite = backCard;
        Card3.GetComponent<SpriteRenderer>().sprite = backCard;
        Card4.GetComponent<SpriteRenderer>().sprite = backCard;
        Card5.GetComponent<SpriteRenderer>().sprite = backCard;
        Card6.GetComponent<SpriteRenderer>().sprite = backCard;
        Card7.GetComponent<SpriteRenderer>().sprite = backCard;
        Card8.GetComponent<SpriteRenderer>().sprite = backCard;
        Card9.GetComponent<SpriteRenderer>().sprite = backCard;
        Card10.GetComponent<SpriteRenderer>().sprite = backCard;

        selectedIndices = new List<int>();
        while (selectedIndices.Count < 10)
        {
            int randomIndex = Random.Range(0, cardFaceSprites.Count);
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
            }
        }


        Card1.GetComponent<FrontCard>().InitializeCard(cardFaceSprites[selectedIndices[0]],backCard, cardValues[selectedIndices[0]]);
        Card2.GetComponent<FrontCard>().InitializeCard(cardFaceSprites[selectedIndices[1]],backCard, cardValues[selectedIndices[1]]);
        Card3.GetComponent<FrontCard>().InitializeCard(cardFaceSprites[selectedIndices[2]],backCard, cardValues[selectedIndices[2]]);
        Card4.GetComponent<FrontCard>().InitializeCard(cardFaceSprites[selectedIndices[3]],backCard, cardValues[selectedIndices[3]]);
        Card5.GetComponent<FrontCard>().InitializeCard(cardFaceSprites[selectedIndices[4]],backCard, cardValues[selectedIndices[4]]);
        Card6.GetComponent<FrontCard>().InitializeCard(cardFaceSprites[selectedIndices[5]],backCard, cardValues[selectedIndices[5]]);
        Card7.GetComponent<FrontCard>().InitializeCard(cardFaceSprites[selectedIndices[6]],backCard, cardValues[selectedIndices[6]]);
        Card8.GetComponent<FrontCard>().InitializeCard(cardFaceSprites[selectedIndices[7]],backCard, cardValues[selectedIndices[7]]);
        Card9.GetComponent<FrontCard>().InitializeCard(cardFaceSprites[selectedIndices[8]],backCard, cardValues[selectedIndices[8]]);
        Card10.GetComponent<FrontCard>().InitializeCard(cardFaceSprites[selectedIndices[9]],backCard, cardValues[selectedIndices[9]]);


        //Player deal logic

        if (Card1.GetComponent<FrontCard>().cardValue == 11){
            playerAceCount++;
        };

        playerHand.Add(Card1);
        playerTotal += Card1.GetComponent<FrontCard>().cardValue;
        playerHandSize++;

        if (Card2.GetComponent<FrontCard>().cardValue == 11){
            playerAceCount++;
        };

        playerHand.Add(Card2);
        playerTotal += Card2.GetComponent<FrontCard>().cardValue;
        playerHandSize++;

        // Dealer deal logic
        if (Card6.GetComponent<FrontCard>().cardValue == 11){
            dealerAceCount++;
        };

        dealerHand.Add(Card6);
        dealerTotal += Card6.GetComponent<FrontCard>().cardValue;
        dealerHandSize++;

        if (Card7.GetComponent<FrontCard>().cardValue == 11){
            dealerAceCount++;
        };

        dealerHand.Add(Card7);
        dealerTotal += Card7.GetComponent<FrontCard>().cardValue;
        dealerHandSize++;

        while (playerAceCount>0 && playerTotal>21){
            playerTotal -= 10;
            playerAceCount--;
        }

        while (dealerAceCount>0 && dealerTotal>21){
            dealerTotal -= 10;
            dealerAceCount--;
        }

        Debug.Log(Card1.GetComponent<FrontCard>().cardValue);
        Debug.Log(Card2.GetComponent<FrontCard>().cardValue);
        Debug.Log(playerTotal);
        

        Card1.GetComponent<Animator>().SetBool("DealCard1Bool", true);
        Card2.GetComponent<Animator>().SetBool("DealCard2Bool", true);
        Card6.GetComponent<Animator>().SetBool("DealCard6Bool", true);
        Card7.GetComponent<Animator>().SetBool("DealCard7Bool", true);
        Card1.GetComponent<SpriteRenderer>().sprite = Card1.GetComponent<FrontCard>().cardFace;
        Card2.GetComponent<SpriteRenderer>().sprite = Card2.GetComponent<FrontCard>().cardFace;
        Card6.GetComponent<SpriteRenderer>().sprite = Card6.GetComponent<FrontCard>().cardFace;
    }

    public void HitFunction()
    {
        if (CheckPlayerBust()){
            return;
        }
        playerHitCount++;
        
        
        if (playerHitCount == 1)
        {
            // Card3 logic
            Card3.GetComponent<Animator>().SetBool("DealCard3Bool", true);
            Card3.GetComponent<SpriteRenderer>().sprite = Card3.GetComponent<FrontCard>().cardFace;
            if (Card3.GetComponent<FrontCard>().cardValue == 11)
            {
                playerAceCount++;
            }
            playerHand.Add(Card3);
            playerTotal += Card3.GetComponent<FrontCard>().cardValue;  // Add Card3 value to playerTotal
            Debug.Log("Card3 value: " + Card3.GetComponent<FrontCard>().cardValue);
            Debug.Log("Updated player total after adding Card3: " + playerTotal);
            playerHandSize++;
        }
        else if (playerHitCount == 2)
        {
            // Card4 logic
            Card4.GetComponent<Animator>().SetBool("DealCard4Bool", true);
            Card4.GetComponent<SpriteRenderer>().sprite = Card4.GetComponent<FrontCard>().cardFace;
            if (Card4.GetComponent<FrontCard>().cardValue == 11)
            {
                playerAceCount++;
            }
            playerHand.Add(Card4);
            playerTotal += Card4.GetComponent<FrontCard>().cardValue;  // Add Card4 value to playerTotal
            Debug.Log("Card4 value: " + Card4.GetComponent<FrontCard>().cardValue);
            Debug.Log("Updated player total after adding Card4: " + playerTotal);
            playerHandSize++;
        }
        else
        {
            // Card5 logic
            Card5.GetComponent<Animator>().SetBool("DealCard5Bool", true);
            Card5.GetComponent<SpriteRenderer>().sprite = Card5.GetComponent<FrontCard>().cardFace;
            if (Card5.GetComponent<FrontCard>().cardValue == 11)
            {
                playerAceCount++;
            }
            playerHand.Add(Card5);
            playerTotal += Card5.GetComponent<FrontCard>().cardValue;  // Add Card5 value to playerTotal
            Debug.Log("Card5 value: " + Card5.GetComponent<FrontCard>().cardValue);
            Debug.Log("Updated player total after adding Card5: " + playerTotal);
            playerHandSize++;
            while (playerTotal > 21 && playerAceCount > 0)
            {
                playerTotal -= 10;
                playerAceCount--;
                Debug.Log("Adjusted player total after converting Ace: " + playerTotal);
            }
            if (!CheckPlayerBust()){
                Debug.Log("5 Card Charlie Player Wins!");
                FiveCardText.SetActive(true);
            } 
        }

        // Adjust for aces right after hitting
        while (playerTotal > 21 && playerAceCount > 0)
        {
            playerTotal -= 10;
            playerAceCount--;
            Debug.Log("Adjusted player total after converting Ace: " + playerTotal);
        }

        if(CheckPlayerBust()){
            Debug.Log("BUSTED");
        }; 
    }


    public void standFunction(){
        if (CheckPlayerBust()){
            return;
        }
        Card7.GetComponent<SpriteRenderer>().sprite = Card7.GetComponent<FrontCard>().cardFace;
        if (dealerTotal < 17){
            Card8.GetComponent<Animator>().SetBool("DealCard8Bool", true);
            Card8.GetComponent<SpriteRenderer>().sprite = Card8.GetComponent<FrontCard>().cardFace;
            if (Card8.GetComponent<FrontCard>().cardValue == 11)
            {
                dealerAceCount++;
            }
            dealerHand.Add(Card8);
            dealerTotal += Card8.GetComponent<FrontCard>().cardValue;  // Add Card3 value to playerTotal
            Debug.Log("Card8 value: " + Card8.GetComponent<FrontCard>().cardValue);
            Debug.Log("Updated dealer total after adding Card3: " + dealerTotal);
            dealerHandSize++;

        }
        if (dealerTotal < 17){
            Card9.GetComponent<Animator>().SetBool("DealCard9Bool", true);
            Card9.GetComponent<SpriteRenderer>().sprite = Card9.GetComponent<FrontCard>().cardFace;
            if (Card9.GetComponent<FrontCard>().cardValue == 11)
            {
                dealerAceCount++;
            }
            dealerHand.Add(Card9);
            dealerTotal += Card9.GetComponent<FrontCard>().cardValue;  // Add Card3 value to playerTotal
            Debug.Log("Card9 value: " + Card8.GetComponent<FrontCard>().cardValue);
            Debug.Log("Updated dealer total after adding Card3: " + dealerTotal);
            dealerHandSize++;
        }
        if (dealerTotal < 17){
            Card10.GetComponent<Animator>().SetBool("DealCard10Bool", true);
            Card10.GetComponent<SpriteRenderer>().sprite = Card10.GetComponent<FrontCard>().cardFace;
            if (Card10.GetComponent<FrontCard>().cardValue == 11)
            {
                dealerAceCount++;
            }
            dealerHand.Add(Card10);
            dealerTotal += Card10.GetComponent<FrontCard>().cardValue;  // Add Card3 value to playerTotal
            Debug.Log("Card10 value: " + Card10.GetComponent<FrontCard>().cardValue);
            Debug.Log("Updated dealer total after adding Card3: " + dealerTotal);
            dealerHandSize++;
        }
        CompareTotals(playerTotal,dealerTotal);
    }

    private void CompareTotals(int playerTotal, int dealerTotal)
        {
            if (dealerTotal > 21)
            {
                Debug.Log("Dealer busts! Player wins!");
                // Handle player win logic
                WinText.SetActive(true);
            }
            else if (dealerTotal > playerTotal)
            {
                Debug.Log("Dealer wins with " + dealerTotal + " against player " + playerTotal);
                // Handle dealer win logic
                LoseText.SetActive(true);
            }
            else if (dealerTotal < playerTotal)
            {
                Debug.Log("Player wins with " + playerTotal + " against dealer " + dealerTotal);
                // Handle player win logic
                WinText.SetActive(true);
            }
            else
            {
                Debug.Log("It's a tie with " + playerTotal + "!");
                // Handle tie logic
                PushText.SetActive(true);
            }
        }



    private bool CheckPlayerBust()
        {
            // Adjust the total if it exceeds 21 and the player has aces
            while (playerTotal > 21 && playerAceCount > 0)
            {
                playerTotal -= 10; // Convert one ace from 11 to 1
                playerAceCount--;
            }

            // Now check if the player has still busted
            if (playerTotal > 21)
            {
                Debug.Log("Player busts with " + playerTotal + "!");
                // Handle bust (e.g., end the round, disable further hits, etc.)
                BustText.SetActive(true);
                return true;
            }
            else
            {
                Debug.Log("Player is still in the game with " + playerTotal + ".");
                return false;
            }
        }
}


