using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackJack : MonoBehaviour
{

    private static BlackJack instance;
    public static BlackJack Instance { get { return instance; } }

    public enum ePlayer
    {
        Human,
        Dealer
    }



<<<<<<< HEAD
=======


>>>>>>> e5299e4f71f3b72e122e2e3a19998a2d90ee3abe

    //Logic
    Hand playerHand = new Hand();
    Hand dealerHand = new Hand();

    Deck cardDeck = new Deck();

    public void DealerDraw()
    {
        while (dealerHand.HandSum() < 17)
        {
            CardHit(ePlayer.Dealer);
        }
    }

    public void StartingDraw()
    {
        Card card = cardDeck.DrawCard();

        dealerHand.AddCard(card);
        card = cardDeck.DrawCard();
        playerHand.AddCard(card);
        card = cardDeck.DrawCard();
        dealerHand.AddCard(card);
        card = cardDeck.DrawCard();
        playerHand.AddCard(card);

    }

    public void PlayerHit()
    {
        CardHit(ePlayer.Human);
        //Update UI

    }

    public void CardHit(ePlayer target)
    {
        if (target == ePlayer.Human)
        {
            if (playerHand.cards.Count >= 5) return;
            Card newCard = cardDeck.DrawCard();
            playerHand.AddCard(newCard);
        } else
        {
            if (playerHand.cards.Count >= 5) return;
            Card newCard = cardDeck.DrawCard();
            playerHand.AddCard(newCard);
        }
    }


    public void Stand()
    {
        int playerTotal = playerHand.HandSum();
        int dealerTotal = dealerHand.HandSum();

        //Win, lose, or draw
        if (playerTotal > dealerTotal)
        {
            //Player won bet
        } else if (playerTotal < dealerTotal) {
            //Player lost bet
        } else
        {
            //Player keeps bet
        }

        //Reset Deck
        cardDeck = new Deck();
        cardDeck.ShuffleDeck(60);
    }

    private void Awake()
    {
        instance = this;
    }
<<<<<<< HEAD
=======

>>>>>>> e5299e4f71f3b72e122e2e3a19998a2d90ee3abe

    public void Start()
    {
        cardDeck.ShuffleDeck(60);
        StartingDraw();
        DealerDraw();
    }

}
