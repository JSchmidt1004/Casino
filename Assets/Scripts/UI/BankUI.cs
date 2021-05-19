using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BankUI : MonoBehaviour
{
    //public PlayerData playerData;
    TMP_Text TotalChipText;
    TMP_InputField AmountInput;
    int amount = 0;

    void Update()
    {
        //TotalChipText.text = playerData.
    }

    public void OnWithdrawMoney()
    {
        amount = int.Parse(AmountInput.text);
        //playerData.Money or whatever += amount;
        //TotalChipText.text = "Your Total Amount - " + playerData.Money or whatever + "$";
    }

    public void OnDepositMoney()
    {
        amount = int.Parse(AmountInput.text);
        //playerData.Money or whatever -= amount;
        //TotalChipText.text = "Your Total Amount - " + playerData.Money or whatever + "$";
    }
}
