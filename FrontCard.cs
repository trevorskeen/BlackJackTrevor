using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCard : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite cardFace;
    public Sprite cardBack;    
    public int cardValue;
    public void InitializeCard(Sprite frontSprite, Sprite backSprite, int value)
    {
        cardFace = frontSprite;
        cardBack = backSprite;
        cardValue = value;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
