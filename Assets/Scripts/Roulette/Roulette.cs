using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    Roulette instance;
    public Roulette Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }

    
    void Update()
    {
        
    }
}
