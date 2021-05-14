using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBoard : MonoBehaviour
{
    public Node[] nodes;

    void Start()
    {
        nodes = GetComponentsInChildren<Node>();
        Debug.Log(nodes[0].number + " " + nodes[0].isEven + " " + nodes[0].color.ToString());
        Debug.Log(nodes[1].number + " " + nodes[1].isEven + " " + nodes[1].color.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
