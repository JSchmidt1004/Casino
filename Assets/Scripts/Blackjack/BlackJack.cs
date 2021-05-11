using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackJack : MonoBehaviour
{
    public enum ePlayer
    {
        Human,
        Dealer
    }


    //UI
    public List<Image> playerCards;
    public List<Image> dealerCards;

    //Logic
    Hand playerHand = new Hand();
    Hand dealerHand = new Hand();

    Deck cardDeck = new Deck();


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

    public void Start()
    {
        cardDeck.ShuffleDeck(60);
    }

}
