using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayTotalChips : MonoBehaviour
{
    public TMP_Text chipText;
    public PlayerData playerData;

    void Start()
    {
        
    }

    void Update()
    {
        chipText.text = playerData.chips.ToString();
    }
}
