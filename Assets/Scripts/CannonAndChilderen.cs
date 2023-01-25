using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAndChilderen : MonoBehaviour
{
    //cannon children
    public GameObject barrel;
    public GameObject launchPoint;


    //
    private GameObject Maze;
    private BallState ballStateScript;

    //
    [SerializeField] private bool shouldRotateWithMaze = true;
    private void Start()
    {
        Maze = GameObject.FindGameObjectWithTag("Maze");
        ballStateScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BallState>();
    }
    private void Update()
    {
        if (ballStateScript.isInCannon == false && shouldRotateWithMaze == true)
        {
            transform.rotation = Maze.transform.rotation;
        }
            
    }
}
