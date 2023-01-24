using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageShakeBehaviour : MonoBehaviour
{
    private Vector3 stageInitialPos;

    [SerializeField] private float shakeForce;
    [SerializeField] private float resetSpeed;
    [SerializeField] private bool cooldown;
    [SerializeField] private bool canShake;

    // Start is called before the first frame update
    void Start()
    {
        stageInitialPos = transform.position;
        canShake = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShake)
        {
            CheckMouseQuadrant();
        }

        if (cooldown == true && transform.position != stageInitialPos)
        {
            transform.position = Vector3.Lerp(transform.position, stageInitialPos, 0.5f);
        }
        else if (cooldown == true)
        {
            cooldown = false;
            canShake = true;
        }
        else if (canShake == false && cooldown == false)
        {
            canShake = true;
        }
    }

    private void CheckMouseQuadrant()
    {
        print("Click!");
        canShake = false;
        Vector3 clickPosition = Input.mousePosition;

        if (clickPosition.x < (Screen.width / 4))
        {
            StartCoroutine(ShakeLeft());
        }
        else if (clickPosition.x > (Screen.width * 0.75))
        {
            StartCoroutine(ShakeRight());
        }
        else if (clickPosition.y < (Screen.height / 3))
        {
            StartCoroutine(ShakeDown());
        }
        else if (clickPosition.y > Screen.height * 0.6666)
        {
            StartCoroutine(ShakeUp());
        }
    }

    private IEnumerator ShakeLeft()
    {
        print("Left of screen clicked!");
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * shakeForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(resetSpeed);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        cooldown = true;
    }
    private IEnumerator ShakeRight()
    {
        print("Right of screen clicked!");
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * shakeForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(resetSpeed);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        cooldown = true;
    }

    private IEnumerator ShakeDown()
    {
        print("Bottom of screen clicked!");
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * shakeForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(resetSpeed);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        cooldown = true;
    }

    private IEnumerator ShakeUp()
    {
        print("Top of screen clicked!");
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * shakeForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(resetSpeed);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        cooldown = true;
    }
}
