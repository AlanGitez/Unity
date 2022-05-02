using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;

    public float columnMin = -1.7f;
    public float columnMax = 1.7f;
    private float spawnXPosition = 9f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-14, 0);

    private float timeSinceLastSpawn; // contador de respawn
    public float spawnRate;

    private int currentColumn;
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int c = 0; c < columnPoolSize; c++)
        {
            columns[c] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (!GameController.instance.gameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            // rangos maximos: en Y 1.7 y -1.7 en X 9
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
