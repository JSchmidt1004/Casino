using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand
{
    public List<Card> cards { get; set; } = new List<Card>();


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

            switch (card.Rank)
            {
                case Card.eRank.Jack:
                    sum += 10;
                    break;
                case Card.eRank.Queen:
                    sum += 10;
                    break;
                case Card.eRank.King:
                    sum += 10;
                    break;
                default:
                    sum += ((int)card.Rank) + 1;
                    break;
            }  
        }

        if (aceCount > 0 && sum <= 11)
        {
            sum += 10;
        }

        return sum;
    }
}
