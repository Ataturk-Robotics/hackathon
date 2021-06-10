using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody rb;
    public Collider col;
    public float speed;
    public float maxSpeed;
    public float localMaxSpeed;
    public float jumpForce = 5;
    public float localJumpForce;
    public float donutSayısı = 0;
    public float rotateSpeed = 10f;
    float distToGround;
    bool yön;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distToGround = col.bounds.extents.y;
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            rb.velocity = Vector3.Scale(rb.velocity, new Vector3(rb.velocity.x < 0 ? 0 : 1, 1, 1));
            rb.AddForce(new Vector3(speed, 0, 0), ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            rb.velocity = Vector3.Scale(rb.velocity, new Vector3(rb.velocity.x > 0 ? 0 : 1, 1, 1));
            rb.AddForce(new Vector3(-speed, 0, 0), ForceMode.Acceleration);
        }

        localJumpForce = jumpForce / ((donutSayısı + 1f) / 2f);
        if ((Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.Space))) && isGrounded())
        {
            Vector3.Scale(rb.velocity, new Vector3(1, 0, 1));
            rb.velocity += new Vector3(rb.velocity.x, localJumpForce, rb.velocity.z);
        }

        localMaxSpeed = maxSpeed / ((donutSayısı + 1f) / 2f);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, localMaxSpeed);

        if (Mathf.Abs(rb.velocity.x) > 0.1)
        {
            transform.eulerAngles =
                new Vector3(transform.eulerAngles.x,
                (Mathf.Sign(rb.velocity.x) * 90) - 90,
                transform.eulerAngles.x);
            // transform.Rotate(new Vector3(0, (transform.eulerAngles.y > (Mathf.Sign(rb.velocity.x) * 90) - 90) ? -1 : 1, 0)* (rotateSpeed * Time.deltaTime));
        }
        else
        {
            if (transform.eulerAngles.y != 90)
                transform.Rotate(new Vector3(0, (transform.eulerAngles.y > 90) ? -1 : 1, 0) * (rotateSpeed * Time.deltaTime));
        }

        transform.localScale = new Vector3(1, 0.5f, 1) * ((donutSayısı / 2 + 1)) + new Vector3(0, 0.5f, 0);

    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}
