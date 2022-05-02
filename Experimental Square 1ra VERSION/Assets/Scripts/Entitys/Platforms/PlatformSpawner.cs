using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private float StartGameTime;
    [SerializeField] private float currentGameTime;
    [SerializeField] private float timeToRepeat;
    private bool inCoultdawn;

    private bool gameStarted => currentGameTime >= StartGameTime;

    void Start()
    {
        currentGameTime = 0;

        PlatformPool.Instance.PreLoad(platform);

    }

    private void Update()
    {
        currentGameTime += Time.deltaTime;
        GameStart();
    }

    private void GameStart() 
    {     

        if (gameStarted)
        {
            if(!inCoultdawn) StartCoroutine(PlatformSpawn(timeToRepeat));
        }
    }

    private IEnumerator PlatformSpawn(float time)
    {
        inCoultdawn = true;
        PlatformPool.Instance.RequestObject();

        yield return new WaitForSeconds(time);
        inCoultdawn = false;

    }



}
