using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackjackDisplay : MonoBehaviour
{

    private static BlackjackDisplay instance;

    public static BlackjackDisplay Instance { get { return instance; } }

    public List<Image> playerImages = new List<Image>();
    public List<Image> dealerImages = new List<Image>();

    static int playerIndex = 0;
    static int dealerIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResetGame();
    }

    public void PlayerDeal(Sprite img)
    {
        playerImages[playerIndex].sprite = img;
        playerImages[playerIndex].color = Color.white;
        playerIndex++;
    }

    public void DealerDeal(Sprite img)
    {
        dealerImages[dealerIndex].sprite = img;
        dealerImages[dealerIndex].color = Color.white;
        dealerIndex++;
    }

    public void ResetGame()
    {
        playerIndex = 0;
        dealerIndex = 0;
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
