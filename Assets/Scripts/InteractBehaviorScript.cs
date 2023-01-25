/*
 * File Name: InteractBehaviorScript
 * Created By: Nabil Tagba
 * Creation Date: 1/24/23
 * Descrition: interacting with interactable objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviorScript : MonoBehaviour
{


    [SerializeField] private float speed;

    private BallState ballStateScript;
    private Rigidbody2D rb;

    CannonAndChilderen cannonScript;

    int eNthTime = 0;
    /// <summary>
    /// happens when the game starts
    /// </summary>
    void Start()
    {
        ballStateScript = GetComponent<BallState>();
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// happens every frame
    /// </summary>
    void Update()
    {
        //E to interact with
        if (Input.GetKeyUp(KeyCode.E))
        {
            
            GettingInAndOutOfCannon();
            eNthTime++;
            if (eNthTime == 2)
            { 
                eNthTime = 0;
            }

        }

        //aiming the ball
        if (ballStateScript.isInCannon)
        {
            //make ball pos equal to cannon launch pos so it can be aimed
            transform.position = cannonScript.launchPoint.transform.position;
            AimCannon(Input.GetAxis("Horizontal"), 50);

        }

        //shooting out of the cannon
        if (Input.GetMouseButtonUp(0) && ballStateScript.isInCannon)
        {
            ShootOutOfCannon();
        }


    }


    private void GettingInAndOutOfCannon()
    {

        if (ballStateScript.isNextToCannon && eNthTime == 0)
        {
            cannonScript = ballStateScript.cannon.GetComponent<CannonAndChilderen>();
            GetInCannon();



        }
       else if (ballStateScript.isInCannon && eNthTime == 1)
       {
            GetOutOfCannon();
       } 
        
       
        

    }
    private void GetInCannon()
    {
        
        //setting is in cannon equal to true
        ballStateScript.isInCannon = true;
        print(ballStateScript.isInCannon);
    }
    private void GetOutOfCannon()
    {
        //make ball pos not equal to pos of launch pos
        transform.position = transform.position;
        //reseting is in cannon
        ballStateScript.isInCannon = false;
        print(ballStateScript.isInCannon);
        // add a tiny force to get the ball off the cannon

    }

    /// <summary>
    /// rotates an object depending on axis value
    /// </summary>
    /// <param name="axisValue"></param>
    private void AimCannon(float axisValue, float cannonSpeed)
    {
        ballStateScript.cannon.transform.Rotate(.0f, .0f, -axisValue * cannonSpeed * Time.deltaTime);
        transform.rotation = cannonScript.launchPoint.transform.rotation;
        
    }
    private void ShootOutOfCannon()
    {
       
        
        rb.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        ballStateScript.isInCannon = false;
    }

}
