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
        Debug.Log("Lower bet, currently betting " + betCounts[index].text.Trim() + " of chip " + (index+1));
        if (int.Parse(betCounts[index].text.Trim()) <= 0) return;
        betCounts[index].text = (int.Parse(betCounts[index].text.Trim())-1) + "";
         
    }
}
