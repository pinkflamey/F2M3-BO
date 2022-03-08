using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private Rigidbody rb;

    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World! playerMovement script loaded.");

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 5) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(2, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -2) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 2f, 0f, Space.Self);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -2f, 0f, Space.Self);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (canJump == true)
            {
                rb.AddForce(new Vector3(0, 250, 0));
                canJump = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            Debug.Log("I have hit the floor!");
            canJump = true;
        }
    }
}
