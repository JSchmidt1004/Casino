using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Node : Selectable
{
    public int betAmount = 0;
    public bool isSelected = false;

    public override void Select()
    {
        base.Select();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
        Debug.Log("Selected: " + name);
        base.OnSelect(eventData);
    }

    public virtual void Deselect()
    {
        isSelected = false;
        Debug.Log("Deselected: " + name + " Bet Amount: " + betAmount);
    }

    public void ChangeBet(int amount)
    {
        betAmount += amount;
        if (betAmount < 0) betAmount = 0;
    }
}
