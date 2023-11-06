using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawnManager : MonoBehaviour {
    /* We created a public GameObject array called 'crystalPrefabs' that
    will store all the different types of crystals that can spawn (So
    that different coloured crystals can spwan randomly on the moon surface)
    */
    public GameObject[] crystalPrefabs;

    private float spawnRangeX = 120;
    private float spawnRangeY = 20;
    private float spawnRangeZ = 120;

    private float startDelay = 3;
    private float spawnInterval = 10f;
    public int maxCrystals = 10;
    public int crystalCount = 0;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        if (crystalCount < maxCrystals) {
            InvokeRepeating("SpawnRandomCrystal", startDelay, spawnInterval);
            crystalCount++;
        }
        else if (crystalCount == maxCrystals) {
            crystalCount = 10;
        }
    }

    void SpawnRandomCrystal() {
        int i = Random.Range(0, crystalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnRangeY, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(crystalPrefabs[i], spawnPos, crystalPrefabs[i].transform.rotation);
    }

}
