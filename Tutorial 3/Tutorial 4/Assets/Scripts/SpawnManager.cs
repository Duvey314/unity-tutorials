using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewWave(waveNumber);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        if (enemyCount == 0){
            waveNumber++;
            SpawnNewWave(waveNumber);
        }
    }

    void SpawnNewWave(int enemiesToSpawn){
        for (int i = 0; i < enemiesToSpawn; i++){
            Instantiate(enemyPrefab, GenerateSpawnPosition() , enemyPrefab.transform.rotation);

        }
        Instantiate(powerupPrefab ,GenerateSpawnPosition() , powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition(){
        float spawnPositionx = Random.Range(-9, 9);
        float spawnPositionz = Random.Range(-9, 9);

        Vector3 randomPos = new Vector3(spawnPositionx,0,spawnPositionz);

        return randomPos;
    }
}
