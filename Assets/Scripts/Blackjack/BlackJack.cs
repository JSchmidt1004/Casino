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
        BlackjackDisplay.Instance.DealerDeal(Resources.Instance.GetCardSprite(newCard.Suit, newCard.Rank));
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

    public void Start()
    {
        //cardDeck.ShuffleDeck(60);
        //StartingDraw();
        //DealerDraw();
    }

}
