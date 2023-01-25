using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStuff : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Door").SetActive(false);
            Debug.Log("Colliding With Player Button");
            



        }
    }
}