using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] int currentScore = 0;

    public static bool isPaused = false;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
        Time.timeScale = gameSpeed;     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Debug.Log(pauseMenuUI);
            this.pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            ResumeGame();
        }
    }

    public void RestartGame()
    {
        ResumeGame();
        Destroy(gameObject);
        SceneManager.LoadScene("Level 1");
        
    }

    public void MainMenu()
    {
        isPaused = false;
        Destroy(gameObject);
        SceneManager.LoadScene("Start Menu");
        
    }

    private void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = gameSpeed;
        isPaused = false;
    }
}
