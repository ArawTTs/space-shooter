using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyShipPrefab;
    public static enemySpawner EnemySpawner;

    //spawnpoint position outside camera

    public float xPosMax = 2.75f;
    public float xPosMin = -2.75f;
    public float yPosMax = 7f;
    public float yPosMin = 5f;

    float spawnInterval;
    private int currentEnemyShip = 0;

    private void Awake()
    {
        if (EnemySpawner == null)
        {
            EnemySpawner = this;
        }
        else if (EnemySpawner!=this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        spawnInterval = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= Time.deltaTime;

        if (spawnInterval <= 0)
        {
            float spawnXPosition = Random.Range(xPosMax, xPosMin);
            float spawnYPosition = Random.Range(yPosMax, yPosMin);

            GameObject enemyShip = (GameObject)Instantiate(enemyShipPrefab);
            enemyShip.transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentEnemyShip++;
            spawnInterval = Random.Range(1, 3);
        }
    }
}
