using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Deck
{
    public List<Card> cards { get; set; }

    public Deck()
    {
        cards = CreateFullDeck();
    }

    private List<Card> CreateFullDeck()
    {
        List<Card> newDeck = new List<Card>();

        foreach (int i in Enum.GetValues(typeof(Card.eSuit)))
        {
            foreach (int j in Enum.GetValues(typeof(Card.eRank)))
            {
                Card newCard = new Card((Card.eRank)j, (Card.eSuit)i);
                newDeck.Add(newCard);
            }
        }

        return newDeck;
    }

    public Card DrawCard()
    {
        Card drawnCard = cards[cards.Count-1];
        cards.RemoveAt(cards.Count-1);

        return drawnCard;
    }

    public void ShuffleDeck(int swaps)
    {
        System.Random rng = new System.Random();
        for (int i = 0; i < swaps; i++)
        {
            int ind1 = rng.Next(0, cards.Count);
            int ind2 = rng.Next(0, cards.Count);

            Card temp = cards[ind1];
            cards[ind1] = cards[ind2];
            cards[ind2] = temp;
        }
    }

    public void ShuffleDeck()
    {
        ShuffleDeck(50);
    }



}
