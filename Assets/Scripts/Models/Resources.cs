using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    private Resources instance;

    public Resources Instance { get { return instance; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }


    public List<Sprite> cardHearts = new List<Sprite>();
    public List<Sprite> cardSpades;
    public List<Sprite> cardClubs;
    public List<Sprite> cardDiamonds;

    public Sprite backRed;
    public Sprite backGreen;
    public Sprite backBlue;

    private List<List<Sprite>> cards { get { return new List<List<Sprite>> { cardHearts, cardSpades, cardClubs, cardDiamonds }; } }

    public Sprite GetCardSprite(Card.eSuit suit, Card.eRank rank)
    {
        return cards[(int)suit][(int)rank];
    }
}
