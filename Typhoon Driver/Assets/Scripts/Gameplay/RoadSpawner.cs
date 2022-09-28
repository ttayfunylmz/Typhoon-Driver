using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private GameObject roadPrefab;
    private bool isRoadSpawned;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player" && !isRoadSpawned)
        {
            Vector3 spawnLocation = new Vector3(transform.position.x, transform.position.y + 10, 0);
            Instantiate(roadPrefab, spawnLocation, Quaternion.identity);
            isRoadSpawned = true;
            GameManager.score += 10;
            Destroy(this.gameObject, 7f);
        }
        
    }
}
