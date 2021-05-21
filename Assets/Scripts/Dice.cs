using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //in order
    public List<Transform> sideLocators = new List<Transform>();
    public Transform startPosition;
    Rigidbody rb;
    public bool isChecked { get; set; } = false;

    public enum eState
    {
        Waiting, Rolling, Landed
    }

    public eState state = eState.Waiting;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch (state)
        {
            case eState.Waiting:
                isChecked = false;
                rb.position = startPosition.position;
                rb.rotation = startPosition.rotation;
                rb.velocity = Vector3.zero;
                break;
            case eState.Rolling:
                if (rb.velocity == Vector3.zero) state = eState.Landed;
                break;
            case eState.Landed:
                if (isChecked) state = eState.Waiting;
                break;
            default:
                break;
        }
    }

    public void StartRoll()
    {
        state = eState.Rolling;
        
    }



    


}
