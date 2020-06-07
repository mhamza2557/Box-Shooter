using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicGameManager : MonoBehaviour
{
    public static GameManager gm;
    
    public int score = 0;
    public float startTime = 5.0f;

    public Text mainScoreDisplay;
    public Text mainTimerDisplay;

    public GameObject gameOverScoreOutline;

    public AudioSource musicAudioSource;

    public bool gameIsOver = false;

    private float currentTime;

    public bool canBeatLevel = false;
    public int beatLevelScore = 0;

    public GameObject playAgainButtons;
    public string playAgainLevelToLoad;

    public GameObject nextLevelButtons;
    public string nextLevelToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;

        if (gm == null) {
            gm = this.gameObject.GetComponent<GameManager>();
        }

        mainScoreDisplay.text = "0";
        if (gameOverScoreOutline) {
            gameOverScoreOutline.SetActive(false);
        }

        if (playAgainButtons) {
            playAgainButtons.SetActive(false);
        }

        if (nextLevelButtons) {
            nextLevelButtons.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsOver) {
            if (canBeatLevel && (score >= beatLevelScore)) {
                BeatLevel();
            } else if (currentTime < 0) {
                EndGame();
            } else {
                currentTime -= Time.deltaTime;
                mainTimerDisplay.text = currentTime.ToString("0.00");
            }
        }
    }

    private void EndGame() {
        gameIsOver = true;
        mainTimerDisplay.text = "GAME OVER";

        if (gameOverScoreOutline) {
            gameOverScoreOutline.SetActive(true);
        }

        if (playAgainButtons) {
            playAgainButtons.SetActive(true);
        }

        if (musicAudioSource) {
            musicAudioSource.pitch = 0.5f;
        }
    }

    private void BeatLevel() {
        gameIsOver = true;
        mainTimerDisplay.text = "LEVEL IS COMPLETE";

        if (gameOverScoreOutline) {
            gameOverScoreOutline.SetActive(true);
        }

        if (nextLevelButtons) {
            nextLevelButtons.SetActive(true);
        }

        if (musicAudioSource) {
            musicAudioSource.pitch = 0.5f;
        }
    }

    public void targetHit(int scoreAmount, float timeAmount) {
        score += scoreAmount;
        mainScoreDisplay.text = score.ToString();

        currentTime += timeAmount;
        if (currentTime < 0 ) {
            currentTime = 0.0f;
        }
        mainTimerDisplay.text = currentTime.ToString("0.00");
    }

    public void RestartGame() {
        Application.LoadLevel(playAgainLevelToLoad);
    }

    public void NextLevel() {
        Application.LoadLevel(nextLevelToLoad);
    }
}