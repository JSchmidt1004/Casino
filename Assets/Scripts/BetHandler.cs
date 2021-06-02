using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BetHandler : MonoBehaviour
{
    private static BetHandler instance;
    public static BetHandler Instance { get { return instance; } }

    public List<TMP_Text> betCounts = new List<TMP_Text>();
    public TMP_Text totalDisplay;

    public PlayerData playerData;

    private void Update()
    {
        foreach(var txt in betCounts)
        {
            if(txt.text == 0 + "")
            {
                txt.gameObject.SetActive(false);

            }
            else
            {
                txt.gameObject.SetActive(true);
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void BetOnClick(int index)
    {
        if (betCounts[index].text.Equals("")) betCounts[index].text = "0";
        betCounts[index].text = (int.Parse(betCounts[index].text.Trim())+1) + "";

        bool success = int.TryParse(betCounts[index].text.Trim(), out int result);
        betCounts[index].text = ((success) ? result : 0) + 1 + "";
        UpdateTotal();

    }
    public void BackBetOnClick(int index)
    {
        //Debug.Log("Lower bet, currently betting " + betCounts[index].text.Trim() + " of chip " + (index+1));

        if (betCounts[index].text.Equals("")) betCounts[index].text = "0";
        if (int.Parse(betCounts[index].text.Trim()) <= 0) return;
        betCounts[index].text = (int.Parse(betCounts[index].text.Trim())-1) + "";

        bool success = int.TryParse(betCounts[index].text.Trim(), out int result);
        
        if (((success) ? result : 0) <= 0) return;
        betCounts[index].text = (((success) ? result : 1) - 1) + "";
        UpdateTotal();

         
    }
    /// <summary>
    /// Gets the total value of all of the bets combined in dollar values
    /// </summary>
    /// <param name="clearBets">Determines whether or not to clear all of the bets, true means all bets will be set to zero. False will solely grab the values.</param>
    /// <returns></returns>
    public int GetBetValue(bool clearBets)
    {
        //go through each txt and grab its value
        int betTotalValue = 0;
        for (int i = 0; i < betCounts.Count; i++)
        {
            int chipValue = 0;
            //determine which chip we are adding
            switch (i)
            {
                case 0:
                    chipValue = 1;
                    break;
                case 1:
                    chipValue = 5;
                    break;
                case 2:
                    chipValue = 10;
                    break;
                case 3:
                    chipValue = 20;
                    break;
                case 4:
                    chipValue = 50;
                    break;
                case 5:
                    chipValue = 100;
                    break;
                case 6:
                    chipValue = 500;
                    break;
                case 7:
                    chipValue = 1000;
                    break;
                case 8:
                    chipValue = 5000;
                    break;
            }
            //multiply it by its chip value and add it to the total

            int num = (betCounts[i].text.Trim().Equals("")) ? 0 : int.Parse(betCounts[i].text.Trim());
            betTotalValue += (num * chipValue);
            betCounts[i].text = "";

            bool success = int.TryParse(betCounts[i].text.Trim(), out int result);
            betTotalValue += (success) ? (result * chipValue) : 0;
            if(clearBets) betCounts[i].text = "";


        }
        //return that
        playerData.cash -= betTotalValue;
        return betTotalValue;
    }


    public void AddCash(int newCash)
    {
        playerData.cash += newCash;
    }

    public void UpdateTotal()
    {
        totalDisplay.text = "Total Value : $" + GetBetValue(false);
    }

}
