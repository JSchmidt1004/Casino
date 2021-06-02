using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Poker : MonoBehaviour
{

    private static Poker instance;
    public static Poker Instance { get { return instance; } }

    //Logic
    Hand playerHand = new Hand();
    bool[] held = new bool[5];
    private bool hasDrew = false;


    Deck cardDeck;

    public enum eScoreType
    {
        RoyalFlush,
        StraightFlush,
        FourOfAKind,
        FullHouse,
        Flush,
        Straight,
        ThreeOfAKind,
        TwoPairs,
        OnePair,
        NoPair
    }

    public void OnDeckClick()
    {
        if (playerHand.cards.Count == 0)
        {
            StartingDraw();
            PokerDisplay.Instance.UpdateCards(playerHand, held);
        } else
        {
            SwapCards();
            PokerDisplay.Instance.UpdateCards(playerHand, held);
        }
    }

    public void StartingDraw()
    {
        hasDrew = false;
        cardDeck = new Deck();
        cardDeck.ShuffleDeck(60);
        for (int i = 0; i < 5; i++) { held[i] = true; }
        DrawCards(5);
        //Order cards
        playerHand.Sort();
    }

    public void DrawCards(int num)
    {
        for (int i = 0; i < num; i++)
        {
            if (playerHand.cards.Count >= 5) return;
            Card newCard = cardDeck.DrawCard();
            playerHand.AddCard(newCard);
        }
    }

    public eScoreType FindScoreType()
    {
        if (IsRoyalFlush()) return eScoreType.RoyalFlush;
        if (IsStraightFlush()) return eScoreType.StraightFlush;
        if (IsFourOfAKind()) return eScoreType.FourOfAKind;
        if (IsFullHouse()) return eScoreType.FullHouse;
        if (IsFlush()) return eScoreType.Flush;
        if (IsStraight()) return eScoreType.Straight;
        if (IsThreeOfAKind()) return eScoreType.ThreeOfAKind;
        if (IsTwoPairs()) return eScoreType.TwoPairs;
        if (IsOnePair()) return eScoreType.OnePair;
        return eScoreType.NoPair;
    }

    private bool IsRoyalFlush()
    {
        //Ace, 10, Jack, Queen, King, all of same suit
        Card.eSuit testedSuit = playerHand.cards[0].Suit;
        
        if (playerHand.cards[0].Rank == Card.eRank.Ace)
        {
            //Start a index at Card.eRank.Ten
            int enumIndex = 9;
            for (int i = 1; i < playerHand.cards.Count; i++)
            {
                if (playerHand.cards[i].Rank != ((Card.eRank)enumIndex) || playerHand.cards[i].Suit != testedSuit) return false;
                enumIndex++;
            }
            //If didn't escape by now, its a royal flush
            return true;
        }

        return false;
    }

    private bool IsStraightFlush()
    {
        //sequential ranks of same suit
        Card.eSuit testedSuit = playerHand.cards[0].Suit;


        for (int i = 1; i < playerHand.cards.Count; i++)
        {
            try
            {
                Card.eRank expectedRank = (Card.eRank)((int)playerHand.cards[i].Rank) + 1;
                if (playerHand.cards[i].Rank != (expectedRank) || playerHand.cards[i].Suit != testedSuit) return false;
            } catch(Exception e)
            {
                return false;
            }
        }

        //If not escaped by now, it is a straight flush
        return true;
    }

    private bool IsFourOfAKind()
    {
        for (int i = 0; i < 2; i++)
        {
            int count = 1;
            Card.eRank expectedRank = playerHand.cards[i].Rank;

            for (int j = i+1; j < playerHand.cards.Count; j++)
            {
                if (playerHand.cards[j].Rank == expectedRank) count++;
            }

            if (count >= 4) return true;
        }

        //If not escaped by now, not a four of a kind
        return false;
    }

    private bool IsFullHouse()
    {
        //3 cards of one rank, 2 cards of another rank
        Card.eRank firstRank = playerHand.cards[0].Rank;
        int count = 1;
        for (int i = count; i < playerHand.cards.Count; i++, count++)
        {
            if (playerHand.cards[i].Rank != firstRank) break;

            if (count == 3) break;
        }

        Card.eRank secondRank = playerHand.cards[count].Rank;
        int secondCount = 1;
        for (int i = count; i < playerHand.cards.Count; i++, secondCount++)
        {
            if (playerHand.cards[i].Rank != secondRank) break;

            if (secondCount == 3) break;
        }


        return (count + secondCount == 5);
    }

    private bool IsFlush()
    {
        //All five cards in same suit
        Card.eSuit testedSuit = playerHand.cards[0].Suit;

        for (int i = 1; i < playerHand.cards.Count; i++)
        {
            if (playerHand.cards[i].Suit != testedSuit) return false;
        }

        return true;
    }

    private bool IsStraight()
    {
        //all five cards in sequence, not of same rank
        for (int i = 1; i < playerHand.cards.Count; i++)
        {
            try
            {
                Card.eRank expectedRank = (Card.eRank)((int)playerHand.cards[i].Rank) + 1;
                if (playerHand.cards[i].Rank != (expectedRank)) return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        return true;
    }

    private bool IsThreeOfAKind()
    {
        for (int i = 0; i < 3; i++)
        {
            int count = 1;
            Card.eRank expectedRank = playerHand.cards[i].Rank;

            for (int j = i + 1; j < playerHand.cards.Count; j++)
            {
                if (playerHand.cards[j].Rank == expectedRank) count++;
            }

            if (count >= 3) return true;
        }

        //If not escaped by now, not a three of a kind
        return false;
    }

    private bool IsTwoPairs()
    {
        //Two pairs of cards with same rank
        int tracker = 0;
        int pairCount = 0;

        for (int i = 0; i < 4; i++)
        {
            int maxTest = Math.Min(tracker + 2, playerHand.cards.Count - 1);
            for (int j = tracker; j < maxTest; j++)
            {
                if (playerHand.cards[tracker].Rank == playerHand.cards[tracker+1].Rank)
                {
                    pairCount++;
                    i++;
                    break;
                }
                tracker++;
            }

        }

        return (pairCount == 2);
    }

    private bool IsOnePair()
    {
        //Two pairs of cards with same rank

        for (int i = 0; i < 3; i++)
        {
            if (playerHand.cards[i].Rank == playerHand.cards[i + 1].Rank)
            {
                return true;
            }
        }
        return false;
    }

    public void ToggleHoldCard(Button callingButton)
    {
        if (hasDrew) return;
        string charNum = callingButton.name[callingButton.name.Length - 1].ToString();
        int.TryParse(charNum, out int cardIndex);

        held[cardIndex] = !(held[cardIndex]);

        PokerDisplay.Instance.UpdateCards(playerHand, held);
    }

    public void SwapCards()
    {
        if (hasDrew) return;
        for (int i = 0; i < held.Length; i++)
        {
            if (!held[i])
            {
                playerHand.cards[i] = cardDeck.DrawCard();
                held[i] = true;
            }
        }
        hasDrew = true;
        playerHand.Sort();
    }

    public void Hold()
    {
        if (!CanHold()) return;
        int payout = GetPayoutRatio();

        BetHandler.Instance.AddCash(payout);
        Debug.Log("payout: " + payout);

        playerHand.cards.Clear();
        PokerDisplay.Instance.UpdateCards(playerHand, held);
    }

    public bool CanHold()
    {
        foreach (bool b in held)
        {
            if (!b) return false;
        }

        return true;
    }

    private int GetPayoutRatio()
    {
        eScoreType type = FindScoreType();
        int payout = 0;

        switch (type)
        {
            case eScoreType.RoyalFlush:
                payout = 1000000;
                break;
            case eScoreType.StraightFlush:
                payout = 10000;
                break;
            case eScoreType.FourOfAKind:
                payout = 1000;
                break;
            case eScoreType.FullHouse:
                payout = 100;
                break;
            case eScoreType.Flush:
                payout = 50;
                break;
            case eScoreType.Straight:
                payout = 25;
                break;
            case eScoreType.ThreeOfAKind:
                payout = 10;
                break;
            case eScoreType.TwoPairs:
                payout = 5;
                break;
            case eScoreType.OnePair:
                payout = 1;
                break;
            case eScoreType.NoPair:
                payout = 0;
                break;
            default:
                break;
        }

        return payout * BetHandler.Instance.ConfirmBets();
    }


    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        StartingDraw();
        PokerDisplay.Instance.UpdateCards(playerHand, held);
    }

}

