using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    
    // Update is called once per frame
    void Update()
    {
        Rotate(Input.GetAxis("Horizontal"));
    }

    private void Rotate(float axisValue)
    {
        transform.Rotate(.0f,.0f, -axisValue * speed * Time.deltaTime);
    }
}
