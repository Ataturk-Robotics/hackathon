using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Player : MonoBehaviour
{
    public GameController game;
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
    public GameObject floor;
    bool isTriggered;
    public GameObject donutPrefab;
    public GameObject donutParent;
    public int donutCount = 1;

    void Start()
    {
    }
    void Update()
    {
        distToGround = col.bounds.extents.y;
        Physics.gravity = new Vector3(0, -20 * (donutSayısı / 6 + 1), 0);
        animasyonKontrol();

        rb.isKinematic = game.pause;
        if (game.gameOver || game.pause) { }
        else if (game.otomatik)
        {
            zıplamaKontrol();
            rb.velocity = new Vector3(speed * (donutSayısı / 4 + 1) + game.puan / 500, rb.velocity.y, 0);
        }
        else
        {
            serbestHareket();
        }

        transform.localScale = new Vector3(1, 0.5f, 1) * ((donutSayısı / 2 + 1)) + new Vector3(0, 0.5f, 0);
        // rb.mass = donutSayısı + 1;
        floor.transform.position = new Vector3(transform.position.x, -2, 0);

        if ((int)((game.puan + 40) / 30) > donutCount)
        {
            GameObject d = Instantiate(
                donutPrefab,
                new Vector3(transform.position.x + Random.Range(20, 30), Random.Range(0, 2) * 4, 0),
                new Quaternion(-0.707106829f, 0, 0, 0.707106709f)
                );
            donutCount++;
        }
    }


    void animasyonKontrol()
    {
        if (isGrounded())
            GetComponent<Animator>().Play(Mathf.Abs(rb.velocity.x) > 0.1 ? "Run" : "Idle");
        else GetComponent<Animator>().Play("Air");
    }

    void zıplamaKontrol()
    {
        // localJumpForce = jumpForce / ((donutSayısı + 2f) / 2f);
        localJumpForce = jumpForce;
        if ((Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.Space))) && isGrounded())
        {
            game.sfx.playSoundById(1);
            Vector3.Scale(rb.velocity, new Vector3(1, 0, 1));
            rb.AddForce(new Vector3(0, localJumpForce, 0), ForceMode.Impulse);
        }
    }

    void serbestHareket()
    {
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

        zıplamaKontrol();

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

    }

    /*
    void FixedUpdate()
    {
        distToGround = col.bounds.extents.y;
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            rb.velocity = Vector3.Scale(rb.velocity, new Vector3(rb.velocity.x < 0 ? 0 : 1, 1, 1));
            rb.AddForce(new Vector3(speed, 0, 0), ForceMode.Acceleration);
        }
        // if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        // {
        //     rb.velocity = Vector3.Scale(rb.velocity, new Vector3(rb.velocity.x > 0 ? 0 : 1, 1, 1));
        //     rb.AddForce(new Vector3(-speed, 0, 0), ForceMode.Acceleration);
        // }

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
    */

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}
