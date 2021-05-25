using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : IComparable
{
    public enum eRank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public enum eSuit
    {
        Hearts,
        Spades,
        Clubs,
        Diamonds
    }

    public eRank Rank { get; set; } = eRank.Ace;
    public eSuit Suit { get; set; } = eSuit.Hearts;

    public Card(eRank rank, eSuit suit)
    {
        Rank = rank;
        Suit = suit;
    }


    public int CompareTo(object obj)
    {
        if (!(obj is Card)) throw new ArgumentException("Not a card, cannot compare");
        int difference = ((int)Rank) - ((int)(obj as Card).Rank);

        //below 0 - current card precedes
        //0 - cards have same value
        //over 0 - current card is after
        return difference;
    }
}
