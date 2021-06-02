using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //in order
    public List<Transform> sideLocators = new List<Transform>();
    public Transform startPosition;
    public bool isChecked { get; set; } = false;
    public float timer = 0;
    Rigidbody rb;

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
                timer += Time.deltaTime;
                if (rb.velocity == Vector3.zero && timer > 0.5f) state = eState.Landed;
                break;
            case eState.Landed:
                timer = 0;
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
