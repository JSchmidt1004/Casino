using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapsBoard : MonoBehaviour
{

    public BetButton[] nodes;
    // Start is called before the first frame update
    void Start()
    {
        nodes = GetComponentsInChildren<BetButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
