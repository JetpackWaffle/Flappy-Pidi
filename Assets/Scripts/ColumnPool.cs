using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    private GameObject[] columns;
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    private Vector2 objectPoolPosition = new Vector2 (-15f,-25f);

    private float timeSinceLastSpawned;
    public float spawnRate = 4f;
    private float actualSpawnRate;
    public float spawnRateMultiplier;
    public float minimumSpawnRate;

    public float columnMin = -1f;
    public float columnMax = 3f;
    public float spawnXPosition = 6f;
    private int currentColumn = 0;


    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns [i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity);
        }
        actualSpawnRate = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (actualSpawnRate > minimumSpawnRate)
            actualSpawnRate = (spawnRate - (GameControl.instance.score / spawnRateMultiplier));

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= actualSpawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range (columnMin, columnMax);

            columns[currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
                currentColumn = 0;
        }
    }
}
