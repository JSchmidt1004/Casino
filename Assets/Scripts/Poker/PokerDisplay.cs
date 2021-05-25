using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokerDisplay : MonoBehaviour
{

    private static PokerDisplay instance;

    public static PokerDisplay Instance { get { return instance; } }

    public List<Image> playerImages = new List<Image>();

    static int playerIndex = 0;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResetGame();
    }

    public void PlayerDeal(Sprite img)
    {
        playerImages[playerIndex].sprite = img;
        playerImages[playerIndex].color = Color.white;
        playerIndex++;
    }

    public void UpdateCards(Hand playerHand, bool[] held)
    {
        //Hide cards if list empty
        if (playerHand.cards.Count == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                playerImages[i].color = Color.clear;
            }
            return;
        }

        //Update cards if list is populated
        for (int i = 0; i < playerHand.cards.Count; i++)
        {
            Card card = playerHand.cards[i];
            playerImages[i].sprite = (held[i]) ? Resources.Instance.GetCardSprite(card.Suit, card.Rank) : Resources.Instance.backRed;
            playerImages[i].color = Color.white;
            
        }
    }

    public void ResetGame()
    {
        playerIndex = 0;
        foreach (var img in playerImages)
        {
            img.sprite = null;
        }
    }

    public void PlayerBet()
    {
        //playerImages[playerIndex].GetComponentInChildren<Image>().sprite = resources
    }

    

}
