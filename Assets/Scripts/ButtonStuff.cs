using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStuff : MonoBehaviour
{
    [SerializeField] private GameObject doorToOpen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (doorToOpen != null)
            {
                doorToOpen.SetActive(false);
                Debug.Log("Colliding With Player Button");
            }
            
            



        }
    }
}