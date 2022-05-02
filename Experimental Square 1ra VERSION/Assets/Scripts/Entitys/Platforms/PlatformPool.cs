using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private List<GameObject> platformList;
    [SerializeField] private Transform[] positions;

    private static PlatformPool instance;
    public static PlatformPool Instance { get => instance; }


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void PreLoad(GameObject objectToPool) 
    {
        for (int i = 0; i < positions.Length; i++) 
        {
            GameObject gameObj = Instantiate(objectToPool) as GameObject;
            gameObj.transform.SetParent(positions[i]);
            gameObj.transform.position = positions[i].transform.position;
            gameObj.SetActive(false); ;
            platformList.Add(gameObj);
        }
    }

    public GameObject RequestObject()  
    {
        for (int i = 0; i < platformList.Count; i++) 
        {
            if (!platformList[i].activeInHierarchy) 
            {
                platformList[i].SetActive(true);
                return platformList[i];
            }           
        }
        return null;
    }
   
}
