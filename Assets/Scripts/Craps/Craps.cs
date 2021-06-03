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
    //public DiceRoller roll;
    public Text rollText;
    public Text pointText;
    public Text GameState;

    public float waitTime = 6;
    public float waitTimer = 0;

    public List<BetButton> buttons = new List<BetButton>();

    public void Update()
    {
        
    }

    public int EstablishRollDice()
    {
        dice1 = Random.Range(1,6);
        dice2 = Random.Range(1,6);
        //roll.RollDice();

        tempResult = dice1 + dice2;
        EstablishPoint(tempResult);

        rollText.text = "Roll: " + tempResult;

        return tempResult;
    }

    public void RollDice()
    {
        dice1 = Random.Range(1,6);
        dice2 = Random.Range(1,6);

        //roll.RollDice();
        tempResult = dice1 + dice2;

        rollText.text = "Roll: " + tempResult;

        if (sr.sprite == OffSprite)
        {
            GameState.text = "Point Established. Point is " + tempResult;
            EstablishPoint(tempResult);
        }
        else if(sr.sprite == OnSprite)
        {
            //Debug.Log("Game On");
            GameOn(tempResult);
            Debug.Log("AHHHH");
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void EstablishPoint(int point)
    {
        //check if they rolled a 2, 3, or 12
        if(point == 2 || point == 3 || point == 12)
        {
            LosePassBet();
            LosePointBet();
            LoseFieldBet();
            LoseDontPassBet();
            GameState.text = "Loss on Open " + point;
            Debug.Log("Loss On Open " + point) ;
        }

        else if(point == 7 || point == 11)//check if they rolled a 7 or 11
        {
            WinPassBet();
            GameState.text = "Pass Line Win " + point;
            Debug.Log("Pass Line Win " + point);
            
            
        }

        //check if they rolled a 4, 5, 6, 8, 9,10
        else
        {
            sr.sprite = OnSprite;
            GamePoint = point;
            pointText.text = "Point: " + GamePoint;
            //Debug.Log(GamePoint);
            WinPointBet(tempResult);
            //Move the marker on and onto the point
        }
    }

    public void GameOn(int point)
    {
       if(point == GamePoint)
        {
            //Debug.Log("Point: "+ point + "Game Point: " + GamePoint);
            //Debug.Log("Game point reached. Bets won.");
            GameState.text = "Rolled a " + point + ". Game Points Reached. Bets won. Don't pass lost.";

            WinPointBet(tempResult);
            LoseDontPassBet();

            sr.sprite = OffSprite;
        }

       else if(point == 7 || point == 11)
        {
            WinDontPassBet();
            LosePointBet();
            LoseRollBet();
            LoseFieldBet();

            sr.sprite = OffSprite;

            GameState.text = "Rolled a " + point + ". Game Lost, all bets off. Don't pass win.";
            Debug.Log(point + " Game Lost, all bets off");
        }
    }

    public void WinPassBet()
    {
        foreach(BetButton button in buttons)
        {
            if(button.betType == BetButton.SetBet.PASSLINE)
            {
                if(button.bet)
                {
                    button.bet = false;
                }
            }
        }
    }

    public void LosePassBet()
    {

    }

    public void WinDontPassBet()
    {
        foreach (BetButton button in buttons)
        {
            if (button.betType == BetButton.SetBet.DONTPASSLINE)
            {
                if (button.bet)
                {
                    button.bet = false;
                }
            }
        }
    }

    public void LoseDontPassBet()
    {
        foreach (BetButton button in buttons)
        {
            if (button.betType == BetButton.SetBet.DONTPASSLINE)
            {
                if (button.bet)
                {
                    button.bet = false;
                }
                Debug.Log(button.name + " loses");
            }
        }
    }

    public void WinRollBet()
    {
        foreach (BetButton button in buttons)
        {
            if (button.betType == BetButton.SetBet.ROLLBETS)
            {
                if (button.bet)
                {
                    button.bet = false;
                }
                Debug.Log(button.name + " wins");
            }
        }
    }
    public void LoseRollBet()
    {
        foreach (BetButton button in buttons)
        {
            if (button.betType == BetButton.SetBet.ROLLBETS)
            {
                if (button.bet)
                {
                    button.bet = false;
                }
                Debug.Log(button.name + " loses");
            }
        }
    }

    public void WinPointBet(int point)
    {
        foreach(BetButton button in buttons)
        {
            if(button.betType == BetButton.SetBet.POINTBETS)
            {
                int curNum = System.Int32.Parse(button.name);

                if (curNum == point)
                {
                    button.bet = false;
                    Debug.Log(button.name + " wins");
                }
            }

        }
    }

    public void LosePointBet()
    {
        foreach (BetButton button in buttons)
        {
            if (button.betType == BetButton.SetBet.POINTBETS)
            {
                if (button.bet)
                {
                    button.bet = false;
                }
                Debug.Log(button.name + " lose");
            }
        }
    }


    public void WinFieldBet()
    {
        foreach (BetButton button in buttons)
        {
            if (button.betType == BetButton.SetBet.POINTBETS)
            {
                if (button.bet)
                {
                    button.bet = false;
                }
                Debug.Log(button.name + " win");
            }
        }
    }
    public void LoseFieldBet()
    {
        foreach (BetButton button in buttons)
        {
            if (button.betType == BetButton.SetBet.POINTBETS)
            {
                if (button.bet)
                {
                    button.bet = false;
                }
                Debug.Log(button.name + " lose");
            }
        }
    }

}
