using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    static Roulette instance;
    public static Roulette Instance { get { return instance; } }

    public RouletteBoard board;
    public Wheel wheel;
    public PlayerData playerData;

    void Awake()
    {
        instance = this;
    }

    
    void Update()
    {
        
    }

    public void onSpin()
    {

        if (!wheel.isSpinning && GetTotalBetAmount() > 0)
        {
            wheel.Spin();
        }
    }

    public int GetTotalBetAmount(bool reset = false)
    {
        int totalAmount = 0;
        foreach(Node node in board.nodes)
        {
            totalAmount += node.betAmount;
            if (reset) node.betAmount = 0;
        }
        return totalAmount;
    }

    public void HandleBets(int value)
    {
        int rewardAmount = 0;
        if (value != 0)
        {
            Node numberValue = board.FindNodeWithValue(value);
            rewardAmount = numberValue.betAmount * 35;

        }
        playerData.chips -= GetTotalBetAmount(true);
        playerData.chips += rewardAmount;

    }
}
