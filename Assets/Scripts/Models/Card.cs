using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
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

    

}
