using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    
    [SerializeField] private float timeToRepeat;
    private bool inCountdown;

    

    void Start()
    {
      

        PlatformPool.Instance.PreLoad(platform);

    }

    private void Update()
    {
        
          if (!inCountdown) StartCoroutine(PlatformSpawn(timeToRepeat));
    }


    private IEnumerator PlatformSpawn(float time)
    {
        inCountdown = true;
        GameObject obj = PlatformPool.Instance.RequestObject() as GameObject;
        
        yield return new WaitForSeconds(time);
        inCountdown = false;

    }



}
