using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject car;
    public GameObject carSpawner1;
    public GameObject carSpawner2;
    public Transform parent;
    public float spawnTime = 6f;
    public Vector3 position1;
    public Vector3 position2;
    // Start is called before the first frame update
    void Start()
    {
        position1 = carSpawner1.transform.position;
        position2 = carSpawner2.transform.position;
        InvokeRepeating("SpawnCar", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCar()
    {
        var newCar = GameObject.Instantiate(car);
        newCar.transform.position = position1;
        newCar.transform.Rotate(0, 180, 0);
        newCar.transform.SetParent(parent);
        var newCar2 = GameObject.Instantiate(car);
        newCar2.transform.position = position2;
        newCar2.transform.SetParent(parent);
    }
}
