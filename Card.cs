using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer cardFace;  // Reference to the CardFront SpriteRenderer
    public SpriteRenderer cardBack;   // Reference to the CardBack SpriteRenderer (optional if back is fixed)
    
    public string cardName;  // Name of the card (e.g., "Ace of Spades")
    public int cardValue;    // Value of the card (e.g., Ace=1/11, 2=2, etc.)

    // Method to initialize the card
    public void InitializeCard(Sprite frontSprite, string name, int value)
    {
        cardFace.sprite = frontSprite;
        cardName = name;
        cardValue = value;
    }

    // Optionally, you can have methods to flip the card (like before)
    public void FlipCard(bool showFront)
    {
        cardFace.gameObject.SetActive(showFront);
        cardBack.gameObject.SetActive(!showFront);
    }
}

