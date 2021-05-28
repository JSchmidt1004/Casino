using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Node : Selectable
{
    public int betAmount = 0;
    public bool isSelected = false;

    private void Start()
    {
        //yep
    }

    public override void Select()
    {
        base.Select();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
        base.OnSelect(eventData);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        
        base.OnDeselect(eventData);
    }

    public void ChangeBet(int amount)
    {
        betAmount += amount;
        if (betAmount < 0) betAmount = 0;
    }
}
