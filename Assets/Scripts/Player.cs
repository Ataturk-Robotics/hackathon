using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody rb;
    public Collider col;
    public float speed;
    public float maxSpeed;
    public float jumpForce = 200;
    float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        distToGround = col.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow))) && rb.velocity.x < maxSpeed)
        {
            rb.AddForce(new Vector3(speed, 0, 0), ForceMode.Acceleration);
        }
        if ((Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow))) && rb.velocity.x > -maxSpeed)
        {
            rb.AddForce(new Vector3(-speed, 0, 0), ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.Space)))
        {
            if (isGrounded())
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}
