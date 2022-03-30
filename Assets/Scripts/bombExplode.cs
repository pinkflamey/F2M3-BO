using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExplode : MonoBehaviour
{
    public GameObject explosionPrefab;

    public float radius = 10f;
    public float explosionPower = 5f;
    public float upwardsMod = 3f;
    public Collider[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Explode());
    }

    internal Collider[] GetColliders()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        return colliders;
    }

    internal void Explosion(Collider[] colliderList)
    {
        foreach (Collider collider in colliderList)
        {
            Debug.Log(collider.name);
            if (collider.GetComponent<Rigidbody>() != null)
            {
                if (collider.name != "Bomb" && collider.name != "UFO")
                {
                    Rigidbody rb = collider.GetComponent<Rigidbody>();

                    rb.AddExplosionForce(explosionPower, transform.position, radius, upwardsMod);
                }
            }
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2.0f);

        Explosion(GetColliders());

        Destroy(gameObject);
        GameObject particle = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(particle, 1.5f);
    }

    
}
