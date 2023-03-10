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

    [SerializeField] private RotationMemory rotationMemory;
    private bool canChangeSpeed = true;

    private BallState ballStateScript;
    public TMP_Text RotateText;
    private BallState bs;


    private Rigidbody2D rb;

    /// <summary>
    /// happens once when the game starts
    /// </summary>
    private void Start()
    {
        bs = GameObject.FindGameObjectWithTag("Player").GetComponent<BallState>();
        ballStateScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BallState>();
        speed = rotationMemory.RotationSpeed;
        rb = GetComponent<Rigidbody2D>();

        if (bs.nextRoom != 1)
        {
            RotateText.text = ((speed/500) -1).ToString();
        }
        else
        {
            rotationMemory.RotationSpeed = 2000;
        }
    }

    /// <summary>
    /// updates every frame
    /// </summary>
    private void FixedUpdate()
    {
        //transform.position = Vector2.zero;
        Rotate(Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.W) && bs.nextRoom != 1 && canChangeSpeed)
        {
            StartCoroutine(IncreaseSpeed());
        }
        else if (Input.GetKey(KeyCode.S) && bs.nextRoom != 1 && canChangeSpeed)
        {
            StartCoroutine(DecreaseSpeed());
        }

    }

    private IEnumerator IncreaseSpeed()
    {
        // Disallows further change until cooldown is over
        canChangeSpeed = false;
        // Increases rotation speed
        speed = Mathf.Clamp(speed += rotSpeed, minSpeed, maxSpeed);
        RotateText.text = ((speed/500) -1).ToString();
        // Updates memory
        rotationMemory.RotationSpeed = speed;
        yield return new WaitForSeconds(0.1f);
        canChangeSpeed = true;
    }

    private IEnumerator DecreaseSpeed()
    {
        // Disallows further change until cooldown is over
        canChangeSpeed = false;
        // Decreases rotation speed
        speed = Mathf.Clamp(speed -= rotSpeed, minSpeed, maxSpeed);
        RotateText.text = ((speed/500) -1).ToString();
        // Updates memory
        rotationMemory.RotationSpeed = speed;
        yield return new WaitForSeconds(0.1f);
        canChangeSpeed = true;
    }

    /// <summary>
    /// rotates an object depending on axis value
    /// </summary>
    /// <param name="axisValue"></param>
    private void Rotate(float axisValue)
    {

            rb.angularVelocity = -axisValue * speed * Time.deltaTime;
            //print("should be rotating");
      
    }

    /// <summary>
    /// increases the speed of rotation depending on the direction the player scrolls
    /// </summary>
    /// <param name="scrollInput"></param>
    /* private void IncreaseRotationalSpeed(float scrollInput) 
    {
        //increasing and decreasing speed
        speed += scrollInput * rotSpeed;

        // clamping speed
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
    } */

    /* private void ScrollForRotationSpeed()
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
    } */


}
