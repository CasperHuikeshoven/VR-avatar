using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTracking : MonoBehaviour
{
    
    public GameObject prefabToSpawn;
    public GameObject leftHand;
    public GameObject rightHand;
    
    void Update()
    {
        
    }

    public void SpawnAtHand(GameObject hand){
        GameObject spawnedObject = Instantiate(prefabToSpawn);
        spawnedObject.transform.position = hand.transform.position;
        Destroy(spawnedObject, 5);
    }
}
