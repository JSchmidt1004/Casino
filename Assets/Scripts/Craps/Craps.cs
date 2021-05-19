using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craps : MonoBehaviour
{
    private static Craps instance;
    public static Craps Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }

    public int point = 0;

    public void EstablishPoint(int point)
    {
        //Set to point
        this.point = point;

        //Move the marker on and onto the point
        //
    }

    public void ComeOutRoll()
    {

    }

    public void Roll()
    {

    }

    public void OnRoll()
    {

    }

    public void PassBet()
    {
        
    }

    public void DontPassBet()
    {

    }

    public void SetBet(float modifier)
    {

    }
}
