using UnityEngine;

public class CardSettingsButton : MonoBehaviour
{
    public void SetCardBack(int cardBackIndex)
    {
        PlayerPrefs.SetInt("SelectedCardBack", cardBackIndex);
        PlayerPrefs.Save();
        Debug.Log("Card back set to index: " + cardBackIndex);
    }
}

