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
                    SpinWheel();
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
            wheelOneTimer = Random.Range(5, 10);
            wheelTwoTimer = Random.Range(11, 15);
            wheelThreeTimer = Random.Range(16, 20);
        }

        isSpinning = true;
    }

    public void SpinWheel()
    {
        wheelOneImage.sprite = symbols[(wheelOneIndex % symbols.Count)].slotSprite;
        wheelTwoImage.sprite = symbols[(wheelTwoIndex % symbols.Count)].slotSprite;
        wheelThreeImage.sprite = symbols[(wheelThreeIndex % symbols.Count)].slotSprite;

        if (wheelOneTimer > 0) wheelOneTimer -= Time.deltaTime;
        if (wheelTwoTimer > 0) wheelTwoTimer -= Time.deltaTime;
        if (wheelThreeTimer > 0) wheelThreeTimer -= Time.deltaTime;

        if (lastSecond != (int)(wheelThreeTimer % 5))
        {
            lastSecond = (int)(wheelThreeTimer % 5);
            if (wheelOneTimer >= 0) wheelOneIndex++;
            if (wheelTwoTimer >= 0) wheelTwoIndex++;
            if (wheelThreeTimer >= 0) wheelThreeIndex++;
        }
    }
}
