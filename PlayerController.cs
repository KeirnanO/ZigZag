using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;

    public GameManager gm;

    Rigidbody rb;
    public bool grounded;

    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
           rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    //Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            transform.rotation = Quaternion.Euler(0,-45,0);
        }
        else if(Input.GetKeyDown("d"))
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }

        if (grounded)
        {
            if (Input.GetKey("w"))
            {
                rb.AddForce(new Vector2(0, jumpForce));
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag.Equals("Ground"))
        {
            grounded = true;
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag.Equals("Floor"))
        {
            rb.velocity = new Vector3(0, rb.velocity.y);
            grounded = false;
            StartCoroutine(gm.EndGame());
            
        }
    }
}
