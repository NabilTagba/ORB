/******************************************************************************
// File Name     : HazardBehaviour.cs
// Creation Info : Adam Garwacki [1/24/2023]
// Description   : Allows the level to be reset when the ball touches this
//                 script's GameObject.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Hazard"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }   
}
