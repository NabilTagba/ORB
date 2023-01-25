using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBehaviour : MonoBehaviour
{
    public GameObject ball;
    public float bounceForce = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bounce"))
        {
            print("collision!");
            gameObject.GetComponent<Rigidbody2D>().AddForce
                (Vector2.up * bounceForce * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space");
            ball.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce * Time.deltaTime);
        }
    }
}
