using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    Rigidbody2D rigidScroll;

    private void Awake()
    {
        rigidScroll = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidScroll.velocity = Vector2.left * (GameController.instance.scrollSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gameOver)
        {
            rigidScroll.velocity = Vector2.zero;
        }
    }
}
