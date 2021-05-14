using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlackJack : MonoBehaviour
{

    private static BlackJack instance;
    public static BlackJack Instance { get { return instance; } }

    public TMP_Text messageBox;

    public enum ePlayer
    {
        Human,
        Dealer
    }


    //Logic
    Hand playerHand = new Hand();
    Hand dealerHand = new Hand();

    Deck cardDeck = new Deck();

    public void DealerDraw()
    {
        while (dealerHand.HandSum() < 17)
        {
            DealerHit();
        }
    }

    public void StartingDraw()
    {
        DealerHit();
        PlayerHit();
        DealerHit();
        PlayerHit();

    }

    public void PlayerHit()
    {
        Card newCard = CardHit(ePlayer.Human);
        //Update UI
        if (newCard == null) return;
        BlackjackDisplay.Instance.PlayerDeal(Resources.Instance.GetCardSprite(newCard.Suit, newCard.Rank));
    }

    public void DealerHit()
    {
        Card newCard = CardHit(ePlayer.Dealer);
        //Update UI
        if (newCard == null) return;
        Sprite img = (dealerHand.cards.Count > 1) ? Resources.Instance.backRed : Resources.Instance.GetCardSprite(newCard.Suit, newCard.Rank);
        BlackjackDisplay.Instance.DealerDeal(img);
    }



    public Card CardHit(ePlayer target)
    {
        if (target == ePlayer.Human)
        {
            if (playerHand.cards.Count >= 5) return null;
            Card newCard = cardDeck.DrawCard();
            playerHand.AddCard(newCard);
            return newCard;
        } else
        {
            if (dealerHand.cards.Count >= 5) return null;
            Card newCard = cardDeck.DrawCard();
            dealerHand.AddCard(newCard);
            return newCard;
        }
    }


    public void Stand()
    {
        int playerTotal = playerHand.HandSum();
        int dealerTotal = dealerHand.HandSum();

        BlackjackDisplay.Instance.DealerFlip(dealerHand);

        playerTotal = (playerTotal > 21) ? 0 : playerTotal;
        dealerTotal = (dealerTotal > 21) ? 0 : dealerTotal;

        messageBox.gameObject.SetActive(true);
        //Win, lose, or draw
        if (playerTotal > dealerTotal)
        {
            //Player won bet
            messageBox.text = "You win! Poggers";
        } else if (playerTotal < dealerTotal) {
            //Player lost bet
            messageBox.text = "You lost. Boooo";
        } else
        {
            //Player keeps bet
            messageBox.text = "Evenly matched";
        }

        //Reset Deck
        cardDeck = new Deck();
        cardDeck.ShuffleDeck(60);
    }

    private void Awake()
    {
        instance = this;
    }


    public void Start()
    {
        Restart();
    }

    public void Restart()
    {
        BlackjackDisplay.Instance.ResetGame();
        messageBox.gameObject.SetActive(false);
        dealerHand.cards.Clear();
        playerHand.cards.Clear();
        cardDeck.ShuffleDeck(60);
        StartingDraw();
        DealerDraw();
    }

}
