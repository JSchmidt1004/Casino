using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand
{
    private List<Card> cards { get; set; }

    public void AddCard(Card newCard)
    {
        cards.Add(newCard);
    }
}
