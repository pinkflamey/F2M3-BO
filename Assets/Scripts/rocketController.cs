using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketController : bombExplode
{
    public Transform target;

    public float speed = 5f;

    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        Debug.Log(direction);

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

    }

    private void OnCollisionEnter(Collision collision)
    {

        StartCoroutine(Explode());
    }
}
