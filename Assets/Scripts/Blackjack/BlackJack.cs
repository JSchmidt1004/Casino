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
        int sum = dealerHand.HandSum();
        while (sum < 17 && sum != 0 && dealerHand.cards.Count < 5)
        {
            DealerHit();
            sum = dealerHand.HandSum();
        }
    }

    public void StartingDraw()
    {
        BlackjackDisplay.Instance.ResetGame();
        DealerHit();
        PlayerHit();
        DealerHit();
        PlayerHit();
        DealerDraw();
    }

    public void OnDeckClick()
    {
        if (playerHand.cards.Count == 0)
        {
            StartingDraw();
        } else
        {
            PlayerHit();
        }
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
        BlackjackDisplay.Instance.RevealDealer(dealerHand);
        int playerTotal = playerHand.HandSum();
        if (playerTotal > 21) playerTotal = 0;
        int dealerTotal = dealerHand.HandSum();
        if (dealerTotal > 21) dealerTotal = 0;

        //Win, lose, or draw
        if (playerTotal > dealerTotal)
        {
            //Player won bet
            Debug.Log("Won");
            int betTotal = BetHandler.Instance.ConfirmBets();
            BetHandler.Instance.AddCash(betTotal * 2);

        } else if (playerTotal < dealerTotal) {
            //Player lost bet
            Debug.Log("Lose");

            //Take money
            int betTotal = BetHandler.Instance.ConfirmBets();
        } else
        {
            //Player keeps bet
            Debug.Log("Tie");

            int betTotal = BetHandler.Instance.ConfirmBets();
            BetHandler.Instance.AddCash(betTotal);
            
        }

        ResetDeck();
    }

    private void ResetDeck()
    {
        //Reset Deck
        cardDeck = new Deck();
        cardDeck.ShuffleDeck(60);

        playerHand.cards.Clear();
        dealerHand.cards.Clear();
    }

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {

        cardDeck.ShuffleDeck(60);
        StartingDraw();
        
    }

}
