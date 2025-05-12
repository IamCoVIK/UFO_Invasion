using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int score = 0;
    private int missed = 0;

    private int highscore;
    public int miss_limit_base;
    private int miss_limit;

    private bool gamover;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;
    [Space]
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject gamoverUI;
    [SerializeField] private Image health;

    private void Config()
    {
        miss_limit = miss_limit_base;
        gamover = false;
        SetScore(0);
        GetHighscore();
    }

    public void Restart()
    {
        gamoverUI.SetActive(false);
        mainUI.SetActive(true);
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Portal"))
        {
            go.GetComponent<Portal>().DespawnUFO();
            Destroy(go);
        }
        SetScore(0);
        missed = 0;
        miss_limit = miss_limit_base;
        gamover = false;
        Health();
    }

    private void GetHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Рекорд: " + highscore;
    }

    private void SetScore(int value)
    {
        score = value;
        scoreText.text = "Очки: " + score;
    }

    private void SetHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
            highscoreText.text = "Рекорд: " + highscore;
        }
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Очки: " + score;
        SetHighscore();
    }

    public void AddMissed(int value)
    {
        if (gamover)
        {
            return;
        }
        missed += value;
        Health();
        MissCheck();
    }

    public int RemoveMissed(int value)
    {
        if (missed - value < 0 )
        {
            missed = 0;
        }
        else
        {
            missed -= value;
        }
        Health();
        return value;
    }

    public void Health()
    {
        if (health.isActiveAndEnabled)
        {
            health.fillAmount = (float)(miss_limit - missed) / (float)miss_limit;
        }
    }

    private void MissCheck()
    {
        if (missed >= miss_limit)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gamover = true;
        mainUI.SetActive(false);
        gamoverUI.SetActive(true);
    }

    private void Start()
    {
        Config();
    }
}
