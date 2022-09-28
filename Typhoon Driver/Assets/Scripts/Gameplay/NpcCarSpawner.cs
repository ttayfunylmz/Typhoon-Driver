using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject npcCarPrefab;
    [SerializeField] private float spawnTime = 2f;

    private bool canSpawn = true;

    private void Start() 
    {
        StartCoroutine(SpawnNpcCar());
    }

    IEnumerator SpawnNpcCar()
    {
        while(canSpawn == true)
        {
            Instantiate(npcCarPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void SetSpawner(float spawnTimer)
    {
        spawnTime = 2f - spawnTimer;
    }
}
