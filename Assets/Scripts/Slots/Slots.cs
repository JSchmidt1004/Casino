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
    int wheelIndex;
    float wheelTwo;
    float wheelThreeTimer;

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
                break;
            case eState.StartGame:
                wheelOneTimer = Random.Range(2, 5);
                //wheelTwo = Random.Range(6, 10);
                //wheelThree = Random.Range(10, 15);
                break;
            case eState.Game:
                if (isSpinning)
                {
                    wheelOneImage.sprite = symbols[(wheelIndex % symbols.Count)].slotSprite;
                    wheelOneTimer -= Time.deltaTime;
                    if (lastSecond != (int)wheelOneTimer)
                    {
                        lastSecond = (int)wheelOneTimer;
                        wheelIndex++;
                    }

                    if (wheelThreeTimer <= 0) isSpinning = false;
                }
                break;
            case eState.EndGame:
                break;
            default:
                break;
        }
    }

    public void OnLeverPull()
    {
        if (!isSpinning)
        {
            wheelOneTimer = Random.Range(2, 5);
            //wheelTwo = Random.Range(6, 10);
            //wheelThree = Random.Range(10, 15);
        }

        isSpinning = true;
    }
}
