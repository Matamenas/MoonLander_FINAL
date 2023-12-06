using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawnManager : MonoBehaviour {
    /* We created a public GameObject array called 'crystalPrefabs' that
    will store all the different types of crystals that can spawn (So
    that different coloured crystals can spwan randomly on the moon surface)
    */
    public GameObject[] crystalPrefabs;

    private float spawnRangeX = 100;
    private float spawnRangeY = 20;
    private float spawnRangeZ = 100;

    private float startDelay = 2;
    private float spawnInterval = 4f;
    public int maxCrystals = 10;
    public int crystalCount = 0;
    private bool stopSpawn = true;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
            InvokeRepeating("SpawnRandomCrystal", startDelay, spawnInterval);
    }

    void SpawnRandomCrystal() {
        while (stopSpawn && crystalCount < maxCrystals) {
            crystalCount++;
            int i = Random.Range(0, crystalPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnRangeY, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(crystalPrefabs[i], spawnPos, crystalPrefabs[i].transform.rotation);
        }
        stopSpawn = false;
    }
}
