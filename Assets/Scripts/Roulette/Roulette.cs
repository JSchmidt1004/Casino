using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    Roulette instance;
    public Roulette Instance { get { return instance; } }

    public RouletteBoard board;
    public Wheel wheel;

    void Awake()
    {
        instance = this;
    }

    
    void Update()
    {
        
    }

    public void onSpin()
    {
        wheel.Spin();
    }
}
