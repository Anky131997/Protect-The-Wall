using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;
    public GameObject scoreObject;
    public GameObject healthBarObject;
    public GameObject wall;
    public GameObject playerSpwaner;
    public Text scoreShow;

    [HideInInspector]
    public float obstacleSpawnRate;
    [HideInInspector]
    public float playerSpawnRate;
    [HideInInspector]
    public float obstacleSpeed;
    [HideInInspector]
    public float playerSpeed;

    [HideInInspector]
    public Text Score;
    [HideInInspector]
    public HealthBar healthBar;

    int updateScore = 0;
    [HideInInspector]
    public int targetScore = 100;
    [HideInInspector]
    public int compareScore;

    public bool gameOver = false;

    private void Awake()
    {
        instance = this;
        obstacleSpawnRate = 1f;
        playerSpawnRate = 1f;
        obstacleSpeed = -2f;
        playerSpeed = 6f;
    }

    private void Start()
    {
        healthBar = healthBarObject.GetComponent<HealthBar>();
        Score = scoreObject.GetComponent<Text>();

        Time.timeScale = 1;
        healthBar.SetMaxHealth(100);
    }

    private void Update()
    {
        if (compareScore >= targetScore)
        {
            targetScore += 100;

            playerSpawnRate -= 0.04f;
            if (playerSpawnRate <= 0.4f)
            {
                playerSpawnRate = 0.4f;
                
            }

            obstacleSpawnRate -= 0.04f;
            if (obstacleSpawnRate <= 0.4f)
            {
                obstacleSpawnRate = 0.4f;
                
            }

            playerSpeed += 0.05f;
            if (playerSpeed <= 7.5f)
            {
                playerSpeed = 7.5f;
            }

            obstacleSpeed += -0.2f;
            if (obstacleSpeed <= -6.5f)
            {
                obstacleSpeed = -6.5f;
            }
        }
    }

    public void increaseScore(int score)
    {
        if (!gameOver)
        {
            updateScore += score;
            compareScore = updateScore;
            Score.text = updateScore.ToString();
        }
    }
    public void decreaseScore(int score)
    {
        if (!gameOver)
        {
            updateScore -= score;
            if (updateScore < 0)
            {
                updateScore = 0;
            }
            compareScore = updateScore;
            Score.text = updateScore.ToString();
        }
    }

    /*public int scoreCompare()
    {
        int difference = targetScore - compareScore;
        *//*Debug.Log(difference);*//*
        return (difference);
    }*/

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;

        healthBarObject.SetActive(false);
        wall.SetActive(false);
        playerSpwaner.SetActive(false);

        gameOverPanel.SetActive(true);
        scoreShow.text = updateScore.ToString();
        scoreObject.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
