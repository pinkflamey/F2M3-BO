using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private Rigidbody rb;

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
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(2, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -2) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0.5f, 0f, Space.Self);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -0.5f, 0f, Space.Self);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0, 7, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(0, -3.5f, 0) * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            Debug.Log("I have hit the floor!");
        }
    }
}

