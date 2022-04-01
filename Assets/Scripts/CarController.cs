using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public bool mayDrive = false;
    public float speedX = 1f;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mayDrive == true)
            {
                mayDrive = false;
            }
            else if (mayDrive == false)
            {
                mayDrive = true;
            }
        }

        if (mayDrive == true)
        {

            transform.Translate(new Vector3(speedX, 0, 0) * Time.deltaTime);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name != "Floor")
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }


}
