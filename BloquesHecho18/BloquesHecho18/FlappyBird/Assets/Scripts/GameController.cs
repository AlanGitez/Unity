using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText;

    public Text scoreText;

    public bool gameOver;
    public float scrollSpeed = 1.5f;

    private int score;
    private void Awake()
    {
        
        if (GameController.instance == null)
        {
            GameController.instance = this;
        }
        else if (GameController.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("Gamecontroller hga sido instanciado pro segunda vez, esto no deberia suceder");

        }
        
    }
    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void BirdScore()
    {
        if (gameOver) return;

        score++;
        scoreText.text = "Score: " +score;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
           // SceneManager.LoadScene(0);
           //o
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnDestroy()
    {
        if (GameController.instance == this)
        {
            GameController.instance = null;
        }
    }
}

