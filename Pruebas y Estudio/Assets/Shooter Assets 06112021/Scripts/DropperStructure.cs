using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperStructure : Structure
{
    [SerializeField] private WeaponItem itemToDrop;   



    public void DropItem()
    {
        itemToDrop.gameObject.transform.SetParent(null);
        itemToDrop.DropActivate(true);
    }

   

}
