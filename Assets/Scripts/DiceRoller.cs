using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public List<Dice> dice;
    public Transform target;
    [Range(0, 20)]
    public float forceMin = 0;
    [Range(1, 30)]
    public float forceMax = 1;

    public float torqueMin = 0;
    public float torqueMax = 5;

    public Transform TablePlane;

    public int[] Rolls { get; set; } = new int[] { 0, 0 };

    List<Rigidbody> diceBodies = new List<Rigidbody>();

    private void Start()
    {
        foreach(Dice dice in dice)
        {
            diceBodies.Add(dice.GetComponent<Rigidbody>());
        }
    }

    public void RollDice()
    {
        foreach(Rigidbody die in diceBodies)
        {
            Dice dice = die.gameObject.GetComponent<Dice>();
            if (dice.state != Dice.eState.Waiting) return;
            Vector3 direction = target.position - die.position;
            direction = direction / direction.magnitude;
            die.AddForce((direction * Random.Range(forceMin, forceMax)), ForceMode.VelocityChange);
            die.AddTorque(Vector3.one * Random.Range(torqueMin, torqueMax));
            die.gameObject.GetComponent<Dice>().StartRoll();
            
        }
    }



    private void Update()
    {
        bool finished = true;
        
        foreach(Dice die in dice)
        {
            if(die.state != Dice.eState.Landed)
            {
                finished = false;
                break;
            }
        }
        if(finished)
        {
            Debug.Log("Dice are finished rolling");
            //Go through the two dice and check their value and set the Rolls[index] to the value
            int index = 0;
            foreach(Dice dice in dice)
            {
                dice.state = Dice.eState.Landed;
                Transform lowestLocator = null;
                foreach (Transform locator in dice.sideLocators)
                {
                    if (lowestLocator == null) lowestLocator = locator;
                    else
                    {
                        if (locator.position.y < lowestLocator.position.y) lowestLocator = locator;
                    }
                }
                int roll = 7 - (dice.sideLocators.IndexOf(lowestLocator) + 1);
                //Debug.Log(lowestLocator.name + ", " + lowestLocator.position.y);
                //Debug.Log(roll);
                Rolls[index] = roll;
                //Debug.Log(Rolls[index]);
                //dice.isChecked = true;
                index++;
                
            }
            finished = false;

            dice.ForEach(dice => dice.state = Dice.eState.Waiting);

            Debug.Log("Final Result : " + Rolls[0] + ", " + Rolls[1]);

        }
    }
}
