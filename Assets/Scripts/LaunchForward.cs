using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchForward : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float launchSpeed;

    private BallState ballStateScript;
    private RigidbodyConstraints2D initialConstraints;

    //delay
    float delay = 0;
    float maxDelay = 3;

    private float initialGravityScale;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballStateScript = GetComponent<BallState>();
        initialConstraints = rb.constraints;
        initialGravityScale = rb.gravityScale;
    }

    
    void Update()
    {

        
        if (ballStateScript.isInCannon) { rb.constraints = RigidbodyConstraints2D.FreezeRotation; }

        if (ballStateScript.wasLaunched)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 1f;
            rb.AddForce(transform.up * launchSpeed * Time.deltaTime, ForceMode2D.Impulse);
            ballStateScript.wasLaunched = false;
            print(rb.gravityScale);


        }


        if (ballStateScript.wasJustLaunched == false) { rb.gravityScale = initialGravityScale; }

        if (ballStateScript.isInCannon == false)
        {
            delay += Time.deltaTime;
            if (delay >= maxDelay)
            {
                rb.constraints = initialConstraints;
                delay = 0;
            }
            
            
        }

    }
}
