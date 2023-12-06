using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawnManager : MonoBehaviour {
    /* We created a public GameObject array called 'crystalPrefabs' that
    will store all the different types of crystals that can spawn (So
    that different coloured crystals can spwan randomly on the moon surface)
    */
    public GameObject[] bombPrefabs;
    // Start is called before the first frame update

    private float spawnRangeX = 100;
    private float spawnRangeY = 20;
    private float spawnRangeZ = 100;

    private float startDelay = 3;
    private float spawnInterval = 4f;
    public int maxBombs = 10;
    public int BombCount = 0;
    private bool stopSpawn = true;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        InvokeRepeating("SpawnRandomBomb", startDelay, spawnInterval);
    }

        void SpawnRandomBomb() {
            while (stopSpawn && BombCount < maxBombs) {
                BombCount++;
                int i = Random.Range(0, bombPrefabs.Length);
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnRangeY, Random.Range(-spawnRangeZ, spawnRangeZ));
                Instantiate(bombPrefabs[i], spawnPos, bombPrefabs[i].transform.rotation);
            }
            stopSpawn = false;
        }
    }