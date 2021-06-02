using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BankUI : MonoBehaviour
{
    public PlayerData playerData;
    public TMP_Text TotalChipText;
    public TMP_InputField AmountInput;
    public Button Withdraw;
    public Button Deposit;
    static int amount = 0;

    private void Start()
    {
    }

    void Update()
    {
        TotalChipText.text = "Your Total Chip Amount - " + playerData.chips.ToString();
    }

    public void OnWithdrawMoney()
    {
        amount += int.Parse(AmountInput.text);
        playerData.chips += amount;
    }

    public void OnDepositMoney()
    {
        amount -= int.Parse(AmountInput.text);
        playerData.chips += amount;
    }
}
