using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBomb : MonoBehaviour
{

    public GameObject bombPrefab;
    public Vector3 spawnPosition;
    public bool canSpawnBomb;
    public float bombSpawnDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
        canSpawnBomb = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Mouse0) && canSpawnBomb)
        {
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
            canSpawnBomb = false;
            StartCoroutine(bombSpawnTimer());
        }
    }

    private IEnumerator bombSpawnTimer()
    {
        yield return new WaitForSeconds(bombSpawnDelay);
        canSpawnBomb = true;
    }
}
