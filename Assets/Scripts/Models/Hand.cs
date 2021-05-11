using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand
{
    public List<Card> cards { get; set; }

    public void AddCard(Card newCard)
    {
        cards.Add(newCard);
    }

    public int HandSum()
    {
        int sum = 0;
        int aceCount = 0;

        foreach (Card card in cards)
        {
            if (card.Rank == Card.eRank.Ace) aceCount++;
            sum += ((int)card.Rank);
        }

        if (aceCount > 0 && sum <= 11)
        {
            sum += 10;
        }

        return sum;
    }
}
