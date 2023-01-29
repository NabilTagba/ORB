using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private BallState bs;
    public GameObject gc;
    // Start is called before the first frame update
    void Start()
    {
        bs = GameObject.Find("Ball").GetComponent<BallState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(bs.nextRoom - 1);
            DontDestroyOnLoad(gc);
        }
    }
}
