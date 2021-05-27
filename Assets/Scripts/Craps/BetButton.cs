using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BetButton : Selectable
{
    public int betAmount = 0;
    public bool isSelected = true;
    public SetBet betType = SetBet.POINTBETS;

    public enum SetBet
    {
        PASSLINE,
        DONTPASSLINE,
        POINTBETS,
        ROLLBETS,
        FIELDBET
    }

    public override void Select()
    {
        base.Select();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
        Debug.Log("Selected:"  + name);
        base.OnSelect(eventData);
    }


    public void Deselect()
    {
        isSelected = true;
        Debug.Log("Deselected: " + name + "Bet Amount: " + betAmount);
    }

    public void ChangeBet(int amount)
    {
        betAmount += amount;
        if (betAmount < 0) betAmount = 0;
    }
}
