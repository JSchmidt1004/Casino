using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BetButton : Node
{
    public SetBet betType = SetBet.POINTBETS;

    public enum SetBet
    {
        PASSLINE,
        DONTPASSLINE,
        POINTBETS,
        ROLLBETS,
        FIELDBET
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
        Debug.Log("Deselected: " + name + " Bet Amount: " + betAmount);
    }
}
