using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        SpawnWaves();
        gameOver = false;
        restart = false;
        winText.text = "";
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                // as GameObject  
                Instantiate(hazard, spawnPosition, spawnRotation); //as GameObject 
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'N' for Restart" + "  Game by Sarah Emling";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

        if (score >= 100)
        {
            winText.text = "YOU SAVED THE GALAXY!!" + "           Game By Sarah Emling";
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score + "              Pess 'spacebar' to fire";
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over! Game created by Sarah Jane " + "If you want to try again you can!";
        gameOver = true;
    }
   }