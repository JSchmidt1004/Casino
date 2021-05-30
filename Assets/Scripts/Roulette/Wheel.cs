using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float spinTimeMin = 5;
    public float spinTimeMax = 10;
    public GameObject ball;

    WheelPocket[] pockets;
    bool isSpinning = false;
    float spinningTimer;
    float pocketIndex = 0;



    void Start()
    {
        pockets = GetComponentsInChildren<WheelPocket>();
    }

    void Update()
    {
        if (isSpinning)
        {
            spinningTimer -= Time.deltaTime;
            pocketIndex += Time.deltaTime * 10;
            int currentIndex = (int)(Mathf.Round(pocketIndex)) % pockets.Length;
            Vector3 ballLocation = pockets[currentIndex].transform.position;
            Quaternion ballRotation = pockets[currentIndex].transform.rotation;
            ball.transform.position = ballLocation;
            ball.transform.rotation = ballRotation;
            if (spinningTimer <= 0)
            {
                ;
                isSpinning = false; 
                Debug.Log("Stopped On: " + pockets[currentIndex].value);
            }
        }
    }

    public void Spin()
    {
        spinningTimer = Random.Range(spinTimeMin, spinTimeMax);
        isSpinning = true;
    }
}
