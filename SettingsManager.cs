using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public CardSettings cardSettings; // Reference to the ScriptableObject

    public void UpdateCardBack(Sprite newBackSprite)
    {
        cardSettings.cardBackSprite = newBackSprite;
    }
}
