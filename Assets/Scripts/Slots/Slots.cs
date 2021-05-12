using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    
    public enum eState
    {
        Title,
        StartGame,
        Game,
        EndGame
    }

    public eState State { get; set; } = eState.Title;

    private Slots instance;
    public Slots Instance { get { return instance; } }

    public Image wheelOneImage;
    public Image wheelTwoImage;
    public Image wheelThreeImage;

    public List<SlotSymbol> symbols = new List<SlotSymbol>();

    float wheelOneTimer;
    int wheelOneIndex;
    float wheelTwoTimer;
    int wheelTwoIndex;
    float wheelThreeTimer;
    int wheelThreeIndex;

    int lastSecond = 0;
    bool isSpinning = false;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        switch (State)
        {
            case eState.Title:
                State = eState.StartGame;
                break;
            case eState.StartGame:
                wheelOneTimer = Random.Range(5, 10);
                wheelTwoTimer = Random.Range(11, 15);
                wheelThreeTimer = Random.Range(16, 20);
                State = eState.Game;
                break;
            case eState.Game:
                if (isSpinning)
                {
                    wheelOneImage.sprite = symbols[(wheelOneIndex % symbols.Count)].slotSprite;
                    wheelTwoImage.sprite = symbols[(wheelTwoIndex % symbols.Count)].slotSprite;
                    wheelThreeImage.sprite = symbols[(wheelThreeIndex % symbols.Count)].slotSprite;

                    if (wheelOneTimer > 0) wheelOneTimer -= Time.deltaTime;
                    if (wheelTwoTimer > 0) wheelTwoTimer -= Time.deltaTime;
                    if (wheelThreeTimer > 0) wheelThreeTimer -= Time.deltaTime;

                    if (lastSecond != (int)(wheelThreeTimer % 60))
                    {
                        lastSecond = (int)(wheelThreeTimer % 60);
                        wheelOneIndex++;
                        wheelTwoIndex++;
                        wheelThreeIndex++;
                    }

                    if (wheelOneTimer <= 0)
                    {
                        isSpinning = false;
                        GetCash(500);
                    }
                }
                break;
            case eState.EndGame:
                break;
            default:
                break;
        }
    }


    public float GetCash(float bet)
    {
        string nameOne = symbols[(wheelOneIndex % symbols.Count)].name;
        string nameTwo = symbols[(wheelTwoIndex % symbols.Count)].name;
        string nameThree = symbols[(wheelThreeIndex % symbols.Count)].name;

        //Banana
        //Bars
        //Bell
        //Cherry
        //Lemon
        //Melon
        //Orange
        //Plum
        //Seven

        if (nameOne.Equals("Banana") && nameTwo.Equals("Banana") && nameTwo.Equals("Banana"))
        {
            bet *= 2f;
        }
        else if (nameOne.Equals("Bars") && nameTwo.Equals("Bars") && nameTwo.Equals("Bars"))
        {
            bet *= 0.5f;
        }
        else if (nameOne.Equals("Bell") && nameTwo.Equals("Bell") && nameTwo.Equals("Bell"))
        {
            bet *= 0.5f;
        }
        else if (nameOne.Equals("Bars") && nameTwo.Equals("Bars") && nameTwo.Equals("Bars"))
        {
            bet *= 0.5f;
        }
        else if (nameOne.Equals("Cherry") && nameTwo.Equals("Cherry") && nameTwo.Equals("Cherry"))
        {
            bet *= 0.5f;
        }
        else if (nameOne.Equals("Lemon") && nameTwo.Equals("Lemon") && nameTwo.Equals("Lemon"))
        {
            bet *= 0.5f;
        }
        else if (nameOne.Equals("Melon") && nameTwo.Equals("Melon") && nameTwo.Equals("Melon"))
        {
            bet *= 0.5f;
        }
        else if (nameOne.Equals("Orange") && nameTwo.Equals("Orange") && nameTwo.Equals("Orange"))
        {
            bet *= 0.5f;
        }
        else if (nameOne.Equals("Plum") && nameTwo.Equals("Plum") && nameTwo.Equals("Plum"))
        {
            bet *= 0.5f;
        }
        else if (nameOne.Equals("Seven") && nameTwo.Equals("Seven") && nameTwo.Equals("Seven"))
        {
            bet *= 0.5f;
        }

        return bet;
    }

    public void OnLeverPull()
    {
        if (!isSpinning)
        {
            wheelOneTimer = Random.Range(5, 10);
            wheelTwoTimer = Random.Range(11, 15);
            wheelThreeTimer = Random.Range(16, 20);
        }

        isSpinning = true;
    }
}
