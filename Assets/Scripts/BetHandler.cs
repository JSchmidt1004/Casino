using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BetHandler : MonoBehaviour
{
    public List<TMP_Text> betCounts = new List<TMP_Text>();

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

    public void BetOnClick(int index)
    {
        betCounts[index].text = (int.Parse(betCounts[index].text.Trim())+1) + "";
    }
    public void BackBetOnClick(int index)
    {
        //Debug.Log("Lower bet, currently betting " + betCounts[index].text.Trim() + " of chip " + (index+1));
        if (int.Parse(betCounts[index].text.Trim()) <= 0) return;
        betCounts[index].text = (int.Parse(betCounts[index].text.Trim())-1) + "";
         
    }

    public int ConfirmBets()
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
            betTotalValue += (int.Parse(betCounts[i].text.Trim()) * chipValue);
            betCounts[i].text = "";

        }
        //return that
        return betTotalValue;
    }
}
