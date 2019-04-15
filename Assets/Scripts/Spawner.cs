using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Spawner : MonoBehaviour {

    private int wave = 1;
    private int swarm = 5;          // number spawn per wave
    private float firstWaveTime = 10f;
    private float waveTimer;
    private float spawnTime = 0.5f; // time between every spawn
    private bool display = true;
 
    //public Transform enemyManager;
    private Transform[] enemyWaves;
    public Transform enemyPrefab;
    public Transform bossPrefab;
    public Text waveText;
    public List<Transform> spawnPoints2;

	// Use this for initialization
	void Start () {
        waveTimer = firstWaveTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (wave > 10)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                SceneManager.LoadScene("Victory");
            }
        }
        else
        {

            if (waveTimer <= 0f)
            {
                StartCoroutine(SpawnWave());
                waveTimer = 17f;
                //waveTimer = waveTime * wave;
                display = true;
            }

            else if (waveTimer <= 7f && display)
            {
                StartCoroutine(DisplayWave());
                display = false;
            }
            waveTimer -= Time.deltaTime;
        }
	}

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < swarm * wave * wave; i++)
        {
            SpawnEnemy(1);
            yield return new WaitForSeconds(spawnTime);
        }
        for (int i = 0; i < wave ; i++)
        {
            SpawnEnemy(0);
            yield return new WaitForSeconds(spawnTime * 1.5f);
        }
        wave++;
    }

    private void SpawnEnemy(int arg)
    {

        Transform point = spawnPoints2[UnityEngine.Random.Range(0, spawnPoints2.Count)];
        if (arg == 1)
        {
            Instantiate(enemyPrefab, point.position, enemyPrefab.rotation);
        }
        if (arg == 0)
        {
            Instantiate(bossPrefab, point.position, bossPrefab.rotation);
        }
            


    }

    private IEnumerator DisplayWave()
    {
        waveText.gameObject.SetActive(true);
        waveText.text = "WAVE " + wave;
        yield return new WaitForSeconds(2.0f);
        waveText.gameObject.SetActive(false);
    }

}
