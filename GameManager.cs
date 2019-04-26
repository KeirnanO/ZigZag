using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GroundManager groundManager;
    public PlayerController player;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    bool playing;

    int score;

    private void Start()
    {
        playing = false;
        player.enabled = false;

        highscoreText.text = "highscore: " + PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
            {
                player.enabled = true;
                groundManager.StartGame();
                playing = true;
            }
        }

        if (playing)
        {
            SetScore();
        }

    }

    void SetScore()
    {
        score = (Mathf.Abs(Mathf.RoundToInt(player.transform.position.x)) + Mathf.RoundToInt(player.transform.position.z))/2;

        scoreText.SetText(score.ToString());
    }

    public IEnumerator EndGame()
    {
        playing = false;
        PlayerPrefs.SetInt("Highscore", score);
        highscoreText.text = "highscore: " + PlayerPrefs.GetInt("Highscore");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

               
    }
}
