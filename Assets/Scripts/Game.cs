using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game instance;
    public static Game Instance { get { return instance; } }

    public PlayerData player;


    private void Awake()
    {
        instance = this;
    }

    //Put getPlayerData here
    public PlayerData GetPlayerData()
    {
        return player;
    }
}