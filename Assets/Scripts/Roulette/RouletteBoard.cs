using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RouletteBoard : MonoBehaviour
{
    public NumberNode[] numberNodes;

    void Start()
    {
        numberNodes = GetComponentsInChildren<NumberNode>();
        Debug.Log(numberNodes[0].number + " " + numberNodes[0].isEven + " " + numberNodes[0].color.ToString());
        Debug.Log(numberNodes[1].number + " " + numberNodes[1].isEven + " " + numberNodes[1].color.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
