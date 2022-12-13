using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    public float MinSpeed = 2;
    public float MaxSpeed = 10;
    public float SlowThresholdRange = 3;
    public float constantDrag = 0.2f;

    private Rigidbody rb;
    private GameObject PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        PlayerCamera = FindObjectOfType<Camera>().gameObject;
        constantDrag = rb.drag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);

        // slow the ball down when it get close to the player
        float distance = (transform.position - PlayerCamera.transform.position).magnitude;
        if (distance < SlowThresholdRange)
        {
            rb.drag = constantDrag * (SlowThresholdRange / distance);
        }

        //todo min
        if(rb.velocity.magnitude < MinSpeed)
        {
            rb.velocity = rb.velocity.normalized * MinSpeed;
        }
        /*else if (rb.velocity.magnitude == MinSpeed)
        {
            rb.AddForce(new Vector3(0, 0, 0.1f));
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        // todo
    }
}
