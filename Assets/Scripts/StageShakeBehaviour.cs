/******************************************************************************
// File Name     : StageShakeBehaviour.cs
// Creation Info : Adam Garwacki [1/24/2023]
// Description   : Allows the stage to be shook by clicking on the screen.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageShakeBehaviour : MonoBehaviour
{
    [SerializeField] private float shakeForce;
    [SerializeField] private float resetSpeed;
    [SerializeField] private bool cooldown;
    [SerializeField] private bool canShake;

    private GameObject sceneCamera;

    /// <summary>
    /// Stores the initial position of the stage and allows shaking.
    /// </summary>
    private void Start()
    {
        canShake = true;
        sceneCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    /// <summary>
    /// Shakes the stage, depending on where the player clicks during play.
    /// </summary>
    private void Update()
    {
        if (cooldown)
        {
            sceneCamera.transform.position = Vector3.MoveTowards(sceneCamera.transform.position, 
                new Vector3(transform.position.x, transform.position.y, sceneCamera.transform.position.z), 0.5f);
        }
        
        if (sceneCamera.transform.position == new Vector3(transform.position.x, transform.position.y, sceneCamera.transform.position.z) && cooldown)
        {
            cooldown = false;
            canShake = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<StickyBehaviour>().CanStick = true;
        }

        // If the player has no cooldown, they can shake
        if (canShake == false && cooldown == false)
        {
            canShake = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && canShake)
        {
            canShake = false;
            ShakeUp();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canShake)
        {
            canShake = false;
            ShakeRight();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && canShake)
        {
            canShake = false;
            ShakeDown();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canShake)
        {
            canShake = false;
            ShakeLeft();
        }

    }

    /// <summary>
    /// Shakes the screen to the left.
    /// </summary>
    private void ShakeLeft()
    {
        FreezeVertically();
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * shakeForce, ForceMode2D.Impulse);
        StartCoroutine(ShakeCooldown());
    }

    /// <summary>
    /// Shakes the screen to the right.
    /// </summary>
    private void ShakeRight()
    {
        FreezeVertically();
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * shakeForce, ForceMode2D.Impulse);
        StartCoroutine(ShakeCooldown());
    }

    /// <summary>
    /// Shakes the screen downward.
    /// </summary>
    private void ShakeDown()
    {
        FreezeHorizontally();
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * shakeForce, ForceMode2D.Impulse);
        StartCoroutine(ShakeCooldown());
    }

    /// <summary>
    /// Shakes the screen upward.
    /// </summary>
    private void ShakeUp()
    {
        FreezeHorizontally();
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * shakeForce, ForceMode2D.Impulse);
        StartCoroutine(ShakeCooldown());
    }

    /// <summary>
    /// Freezes the stage aside from its vertical axis.
    /// </summary>
    private void FreezeHorizontally()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    /// <summary>
    /// Freezes the stage aside from its horizontal axis.
    /// </summary>
    private void FreezeVertically()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    /// <summary>
    /// Applies cooldown to the shaking action, and unsticks ball if it was
    /// stuck prior to the shake.
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShakeCooldown()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<StickyBehaviour>().CanStick = false;
        yield return new WaitForSeconds(resetSpeed);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        cooldown = true;
    }
}
