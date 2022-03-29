using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExplode : MonoBehaviour
{
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Explode());
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
        GameObject particle = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(particle, 1.5f);
    }
}
