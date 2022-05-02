using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{     
    public GameObject[] asteroids = new GameObject[5];
    private float[] respawnTime = {3f, 6f};   

    
     private Asteroids asteroidScript;

    private void Awake(){
        asteroidScript = FindObjectOfType<Asteroids>();    
    }

    void Start()
    {
        StartCoroutine(AsteroidSpawn());
       
    }

    void Update()
    {
       
    }

    private IEnumerator AsteroidSpawn(){
        GameObject randomAsteroids = asteroids[Random.Range(0,asteroids.Length)];

        float randomPosX = Random.Range(-34, 34);
        float randomPosY = Random.Range(-21, 21);
        Vector2 randomSpawn = new Vector2(randomPosX, randomPosY);

        GameObject asteroid = Instantiate(randomAsteroids, randomSpawn, Quaternion.identity);
        yield return new WaitForSeconds(respawnTime[Random.Range(0, respawnTime.Length)]);

        StartCoroutine(AsteroidSpawn());
    }
}
