using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketController : bombExplode
{
    public Vector3 target;

    public float speed = 2f;

    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        target = FindClosestEnemy();
        Vector3 direction = target - transform.position;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

    }
    public Vector3 FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                position = closest.transform.position;
                rb.useGravity = false;
            }
        }
        return position;
    }

    private void OnCollisionEnter(Collision collision)
    {

        StartCoroutine(Explode());
    }
}
