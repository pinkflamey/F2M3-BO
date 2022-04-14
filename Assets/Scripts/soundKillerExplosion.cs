using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundKillerExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Die());
    }

    internal IEnumerator Die()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
