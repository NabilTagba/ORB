/******************************************************************************
// File Name     : StickyBehaviour.cs
// Creation Info : Adam Garwacki [1/24/2023]
// Description   : Allows the attached GameObject to stick onto Sticky objects.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBehaviour : MonoBehaviour
{
    [SerializeField] private bool canStick = true;

    /// <summary>
    /// Whether the ball can stick on surfaces or not.
    /// </summary>
    public bool CanStick
    {
        set { canStick = value; }
    }

    /// <summary>
    /// If the player maintains collision with a Sticky surface, they lose
    /// a majority of their velocity.
    /// </summary>
    /// <param name="collision">Data for the collision which occured.</param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.collider.CompareTag("Sticky") && canStick)
        {
            case true:
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                break;
            default:
                break;
        }
    }
}
