/******************************************************************************
// File Name     : RotationMemory.cs
// Creation Info : Adam Garwacki [1/30/2023]
// Description   : Allows rotation speed to persist between scenes.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RotationMemory", menuName = "Rotation Memory")]
public class RotationMemory : ScriptableObject
{
    [SerializeField] private float rotationSpeed;

    public float RotationSpeed
    {
        set { rotationSpeed = value; }
        get { return rotationSpeed; }
    }
}
