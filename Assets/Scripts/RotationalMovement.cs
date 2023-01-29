/*
 * File Name: Rotational Movement
 * Created By: Nabil Tagba
 * Creation Date: 1/20/23
 * Description: provides rotational movement methods
 * and functionality
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RotationalMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float rotSpeed;

    private BallState ballStateScript;
    public TMP_Text RotateText;
    private BallState bs;

    /// <summary>
    /// happens once when the game starts
    /// </summary>
    private void Start()
    {
        bs = GameObject.FindGameObjectWithTag("Player").GetComponent<BallState>();
        ballStateScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BallState>();
    }


    /// <summary>
    /// updates every frame
    /// </summary>
    void Update()
    {
        ScrollForRotationSpeed();
    }
    /// <summary>
    /// rotates an object depending on axis value
    /// </summary>
    /// <param name="axisValue"></param>
    private void Rotate(float axisValue)
    {
        transform.Rotate(.0f,.0f, -axisValue * speed * Time.deltaTime);
    }
    /// <summary>
    /// increases the speed of rotation depending on the direction the player scrolls
    /// </summary>
    /// <param name="scrollInput"></param>
    private void IncreaseRotationalSpeed(float scrollInput) 
    {
        //increasing and decreasing speed
        speed += scrollInput * rotSpeed;

        // clamping speed
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
    }

    private void ScrollForRotationSpeed()
    {
        //binding and executing input
        if (ballStateScript.isInCannon == false)
        {
            //rotation depending on input
            Rotate(Input.GetAxis("Horizontal"));
            // in every scene but the main menu...
            if (bs.nextRoom != 1)
            {
                //increasing speed depending on input
                IncreaseRotationalSpeed(Input.mouseScrollDelta.y);
                RotateText.text = "Rotation Speed: " + speed.ToString();
            }

        }
    }
}
