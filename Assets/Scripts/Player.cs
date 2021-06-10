using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow)))&&rb.velocity.x<30)
        {
            rb.AddForce(new Vector3(20,0,0),ForceMode.Acceleration);
        }
        else if ((Input.GetKey(KeyCode.A)||(Input.GetKey(KeyCode.LeftArrow)))&&rb.velocity.x>-30)
        {
            rb.AddForce(new Vector3(-20,0,0),ForceMode.Acceleration);
        }   
    }
}
