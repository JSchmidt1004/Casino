using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    List<Sprite> symbols = new List<Sprite>();
                  
    float wheelOne;
    float wheelTwo;
    float wheelThree;

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
                wheelTwo = Random.Range(6, 10);
                wheelThree = Random.Range(10, 15);
                break;
            case eState.Game:

                break;
            case eState.EndGame:
                break;
            default:
                break;
        }
    }

    public void OnLeverPull()
    {
        wheelOne = Random.Range(2, 5);
        wheelTwo = Random.Range(6, 10);
        wheelThree = Random.Range(10, 15);
    }
}
