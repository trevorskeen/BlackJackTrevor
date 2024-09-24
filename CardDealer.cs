using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public GameObject cardPrefab; // The card prefab with the animation
    public Transform deckPosition; // Where the deck is located (start position)
    public Transform playerHandPosition; // Target position (player's hand)

    // Deal the first card
    public void DealFirstCard()
    {
        // Instantiate the card at the deck position
        GameObject dealtCard = Instantiate(cardPrefab, deckPosition.position, Quaternion.identity);

        // Get the Animator component from the dealt card
        Animator cardAnimator = dealtCard.GetComponent<Animator>();

        // Move the card to the player's hand (optional, if animation handles this)
        //dealtCard.transform.position = playerHandPosition.position;

        // Play the DealCard1 animation
        cardAnimator.Play("DealCard1");
        cardAnimator.Play("DealCard2"); 
    }
}

