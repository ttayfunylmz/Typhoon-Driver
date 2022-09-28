using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public static int score;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 1000;
    private int scoreToNextLevel = 100;
    private float spawnTimeSubtracter = 0.5f;

    private Sprite playerSprite;

    private void Start() 
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update() 
    {
        if(score >= scoreToNextLevel)
        {
            LevelUp();
        }

        scoreText.text = score.ToString();

        if(score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    private void LevelUp()
    {
        if(difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel+= 3;
        FindObjectOfType<Player>().SetSpeed(difficultyLevel);
        FindObjectOfType<NpcCarSpawner>().SetSpawner(spawnTimeSubtracter);
    }
}
