using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public float minSpawnTime;
    public float maxSpawnTime;

    private float spawnTime;


    public GameObject car;


    // Start is called before the first frame update
    void Start()
    {

        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        StartCoroutine(SpawnCar());
    }

    public IEnumerator SpawnCar()
    {
        yield return new WaitForSeconds(spawnTime);
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

        Instantiate(car, transform.position, transform.rotation);
        StartCoroutine(SpawnCar());

    }
}
