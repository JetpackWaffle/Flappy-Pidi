using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float StartScrollSpeed = -1.5f;
    public float scrollSpeedMultiplier;
    public float scrollSpeed;
    public TMP_Text scoreText;

    public int score = 0;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy (gameObject);
        }
        scrollSpeed = StartScrollSpeed;
    }

    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        scrollSpeed = (StartScrollSpeed - (score / scrollSpeedMultiplier));
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;

        scoreText.text = "Score: " + score.ToString ();
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
