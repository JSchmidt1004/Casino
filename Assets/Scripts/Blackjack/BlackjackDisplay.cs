using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackjackDisplay : MonoBehaviour
{
    public List<Image> playerImages = new List<Image>();
    public List<Image> dealerImages = new List<Image>();
    public Resources resources = new Resources();

    static int playerIndex = 0;
    static int dealerIndex = 0;

    private void Start()
    {
        ResetGame();
    }

    public void PlayerDeal(Sprite img)
    {
        playerImages[playerIndex].sprite = img;
        playerIndex++;
    }

    public void DealerDeal(Sprite img)
    {
        dealerImages[dealerIndex].sprite = img;
        dealerIndex++;
    }

    public void ResetGame()
    {
        foreach (var img in playerImages)
        {
            img.sprite = null;
        }
        foreach (var img in dealerImages)
        {
            img.sprite = null;
        }
    }

    public void PlayerBet()
    {
        //playerImages[playerIndex].GetComponentInChildren<Image>().sprite = resources
    }

    

}
