/*
 * File Name: Ball State
 * Created By: Nabil Tagba
 * Creation Date: 1/24/23
 * Descrition: provides information on the 
 * state of the ball. this can then be use in other
 * scripts
 */

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BallState : MonoBehaviour
{


    // var init
    // state null is when the boll is not in a special state
    // its just in a normal part of the maze
    public bool isInStateNull = true;
    // special states of the the ball
    public bool isInCannon = false;
    public bool isNextToCannon = false;
    public bool isOnStickyWall = false;
    public bool isOnPlatform = false;
    public bool wasLaunched = false;
    public bool wasJustLaunched = false;
    

    //objects in state with
    public GameObject cannon;

    private float justLaunchedDelay = 0;
    
    private void Update()
    {
        if (cannon == null)
        {
            isInCannon = false;
        }

        if (wasLaunched)
        {
            wasJustLaunched = true;
           
        }

        if (wasJustLaunched == true)
        { 
           
            justLaunchedDelay += Time.deltaTime;
            print(justLaunchedDelay);
            if (justLaunchedDelay >= 1)
            {
                wasJustLaunched = false;
                justLaunchedDelay = 0;
            }
        }
    }
    /// <summary>
    /// called on initial collision
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Maze":
                isInStateNull = true;
                break;
            case "Cannon":
                print("Hello World");
                isNextToCannon = true;
                cannon = collision.gameObject;
                break;
            case "Sticky":
                //code
                break;
            default:
                //code
                break;
        }
    }
    /// <summary>
    /// called when collision with said object exits
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Maze":
                isInStateNull = false;
                break;
            case "Cannon":
                isNextToCannon = false;
                break;
            case "Sticky":
                break;
            default:

                break;
        }
    }
    /// <summary>
    /// called while colliding with said object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Maze":
                break;
            case "Cannon":
                break;
            case "Sticky":
                break;
            default:

                break;
        }
    }
}
