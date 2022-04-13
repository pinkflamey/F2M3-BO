using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExplode : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioSource explosionSoundPrefab;

    public float radius = 10f;
    public float explosionPower = 5f;
    public float upwardsMod = 3f;
    public float angularDrag = 5f;
    internal Collider[] colliders;
    public float explosionDelay = 2.0f;

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

            

            if (collider.GetComponent<Rigidbody>() != null)
            {
                if (collider.name != "bombPrefab" && collider.name != "UFO" && collider.name != "rocketPrefab")
                {
                    collider.gameObject.tag = "isDead";

                    if (collider.transform.childCount > 0)
                    {
                        foreach (Transform child in collider.transform)
                        {

                            GameObject childObject = child.gameObject;

                            if(childObject.GetComponent<Rigidbody>() == null)
                            {
                                childObject.AddComponent<Rigidbody>();
                            }

                            Rigidbody crb = child.GetComponent<Rigidbody>();

                            crb.angularDrag = angularDrag;

                            if(childObject.GetComponent<SphereCollider>() == null)
                            {
                                childObject.AddComponent(typeof(SphereCollider));
                            }
                            

                        }
                    }
                    else
                    {
                        Rigidbody rb = collider.GetComponent<Rigidbody>();

                        rb.AddExplosionForce(explosionPower, transform.position, radius, upwardsMod);
                    }
                        
                }
            }
        }
    }

    internal IEnumerator Explode()
    {
        yield return new WaitForSeconds(explosionDelay);

        Explosion(GetColliders());

        Destroy(gameObject);
        AudioSource explosionSound = Instantiate(explosionSoundPrefab, transform.position, Quaternion.identity);
        GameObject particle = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        
        Destroy(particle, 1.5f);
    }

    
}
