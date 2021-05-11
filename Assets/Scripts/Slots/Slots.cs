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
                  
    float wheelOne;
    float wheelTwo;
    float wheelThree;
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
                wheelOne = Random.Range(2, 5);
                //wheelTwo = Random.Range(6, 10);
                //wheelThree = Random.Range(10, 15);
                break;
            case eState.Game:
                if (isSpinning)
                {
                    wheelOneImage.sprite = symbols[(int)wheelOne].slotSprite;
                    wheelOne -= Time.deltaTime;

                    if (wheelThree <= 0) isSpinning = false;
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
            wheelOne = Random.Range(2, 5);
            //wheelTwo = Random.Range(6, 10);
            //wheelThree = Random.Range(10, 15);
        }

        isSpinning = true;
    }
}
