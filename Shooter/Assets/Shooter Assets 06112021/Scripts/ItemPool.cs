using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    [SerializeField] private GameObject[] items; 
    [SerializeField] private List<GameObject> weaponItemList = new List<GameObject>();
    //[SerializeField] private float poolSize = 3;

    private static ItemPool instance;

    public static ItemPool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        


        for (int i = 0; i < weaponItemList.Count; i++)
        {
            AddToPool(weaponItemList[i]);
        }
        
    }


    public GameObject GetWeaponItem(GameObject position, string tag) 
    {
        GameObject myObj = new GameObject();
        foreach (var obj in weaponItemList) 
        {
            if (obj.tag == tag) 
            {
                if (!obj.activeSelf) 
                {
                    obj.SetActive(true);
                    return obj;
                }
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].tag == tag)
                    {
                        myObj = items[i];
                        weaponItemList.Add(myObj);
                        AddToPool(myObj);
                        myObj.transform.position = position.transform.position;
                    }

                }
            }
            
        }
        return myObj;
    }

    private void AddToPool(GameObject item) 
    {
        GameObject myObj = Instantiate(item, transform.position, Quaternion.identity);
        myObj.transform.SetParent(this.gameObject.transform);
        myObj.SetActive(false);

    }
}
