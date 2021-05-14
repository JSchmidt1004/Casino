using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public enum eColor
    {
        Red,
        Black,
        Green
    }

    public int number;
    public eColor color;
    public bool isEven { get; set; }


    void Awake()
    {
        isEven = (number % 2 == 0) ? true : false;
    }

    void Update()
    {
        
    }
}
