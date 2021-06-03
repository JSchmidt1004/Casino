using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BetButton : MonoBehaviour
{
    public GameObject currentObject;
    public SetBet betType = SetBet.POINTBETS;

    public bool bet = false;
    public Image sr = null;
    public Sprite SelectSprite;
    public Sprite UnselectedSprite;

    public enum SetBet
    {
        PASSLINE,
        DONTPASSLINE,
        POINTBETS,
        ROLLBETS,
        FIELDBET
    }

    public void Start()
    {
    
    }

    public void Update()
    {
        if(bet == false)
        {
            sr.sprite = UnselectedSprite;
        }
        else
        {
            sr.sprite = SelectSprite;
        }
    }

    public void TestClick()
    {
        Debug.Log(betType.ToString());
        //this.isActiveAndEnabled = true;
        //sr.sprite =
        bet = true;
        
    }

}
