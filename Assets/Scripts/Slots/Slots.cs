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
    float wheelTwoTimer;
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
                    wheelOneImage.sprite = symbols[(wheelIndex % symbols.Count)].slotSprite;
                    wheelOneTimer -= Time.deltaTime;
                    if (lastSecond != (int)(wheelOneTimer % 60))
                    {
                        lastSecond = (int)(wheelOneTimer % 60);
                        wheelIndex++;
                    }

                    if (wheelOneTimer <= 0) isSpinning = false;
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
}
