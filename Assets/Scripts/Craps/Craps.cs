using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Craps : MonoBehaviour
{
    private static Craps instance;
    public static Craps Instance { get { return instance; } }

    public int dice1 = 0;
    public int dice2= 0;
    public int tempResult = 0;

    public int GamePoint = 0;
    public GameObject marker;
    public Image sr = null;
    public Sprite OnSprite;
    public Sprite OffSprite;

    public int EstablishRollDice()
    {
        dice1 = Random.Range(1,6);
        dice2 = Random.Range(1,6);
        tempResult = dice1 + dice1;

        EstablishPoint(tempResult);

        return tempResult;
    }

    public void RollDice()
    {
        dice1 = Random.Range(1,6);
        dice2 = Random.Range(1,6);
        tempResult = dice1 + dice1;

        Debug.Log(tempResult);
        EstablishPoint(tempResult);
    }

    private void Awake()
    {
        instance = this;
    }

    public int point = 0;

    public void EstablishPoint(int point)
    {
        //check if they rolled a 2, 3, or 12
        if(point == 2 || point == 2 || point == 12)
        {
            Debug.Log("Loss On Open");
        }

        else if(point == 7 || point == 11)//check if they rolled a 7 or 11
        {
            Debug.Log("Pass Line Win");
        }

        //check if they rolled a 4, 5, 6, 8, 9,10
        else
        {
            sr.sprite = OnSprite;
            GamePoint = point;
            Debug.Log(point);
            //Move the marker on and onto the point


        }

    }

    public void ComeOutRoll()
    {
 
    }

    public void Roll()
    {

    }
/*
    public void OnRoll()
    {

    }*/

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
