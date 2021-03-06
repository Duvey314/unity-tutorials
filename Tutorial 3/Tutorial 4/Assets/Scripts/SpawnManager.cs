using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(enemyPrefab, GenerateSpawnPosition() , enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition(){
        float spawnPositionx = Random.Range(-9, 9);
        float spawnPositionz = Random.Range(-9, 9);

        Vector3 randomPos = new Vector3(spawnPositionx,0,spawnPositionz);

        return randomPos;
    }
}
