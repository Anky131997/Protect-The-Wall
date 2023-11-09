using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpwaner : MonoBehaviour
{
    public GameObject[] obstacles;
    Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        /*spawnRate = 1f;*/
        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver)
        {
            StopCoroutine("SpawnObstacles");
        }

        /*if (GameManager.instance.targetScore - GameManager.instance.compareScore <= 100)
        {
            GameManager.instance.targetScore += 100;
            spawnRate -= 0.04f;
            if (spawnRate <= 0.4f)
            {
                spawnRate = 0.4f;
            }
        }*/
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(GameManager.instance.obstacleSpawnRate);
        }
    }

    void Spawn()
    {
        int randNumber = Random.Range(0, 16);

        float randXpos = Random.Range(2.10f, -2.10f);

        spawnPos.x = randXpos;

        if (randNumber == 0 || randNumber == 1)
        {
            GameObject test = Instantiate(obstacles[2], spawnPos, Quaternion.identity);
            /*Destroy(test, 10);*/
        }
        else if (randNumber == 2 || randNumber == 3 || randNumber == 4)
        {
            GameObject test = Instantiate(obstacles[1], spawnPos, Quaternion.identity);
            /*Destroy(test, 10);*/
        }
        else
        {
            GameObject test = Instantiate(obstacles[0], spawnPos, Quaternion.identity);
            /*Destroy(test, 10);*/
        }
    }
}
