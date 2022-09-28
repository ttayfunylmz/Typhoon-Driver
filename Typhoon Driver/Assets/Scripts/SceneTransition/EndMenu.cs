using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;

    private void Start() 
    {
        ScoreDisplay();
        HighScoreDisplay();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadSkinSelectionScene()
    {
        SceneManager.LoadScene("SkinSelection");
        BackgroundMusic.instance.gameObject.GetComponent<AudioSource>().UnPause();
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
        BackgroundMusic.instance.gameObject.GetComponent<AudioSource>().UnPause();
    }

    private void ScoreDisplay()
    {
        scoreText.text = "Your Score : " + GameManager.score;
    }

    private void HighScoreDisplay()
    {
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("highScore").ToString();
    }
}
