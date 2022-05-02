
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRepeat : MonoBehaviour
{
    
    private void Repeat()
    {
        float newPositionY = transform.position.y + (transform.localScale.y * 2);
        Vector2 repositionVec = new Vector2(transform.position.x, newPositionY);

        transform.position = (repositionVec);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {            
            Invoke("Repeat", 1f);
        }
    }
}
