using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text score;

    private void Start()
    {
        score.text = "Рекорд: " + PlayerPrefs.GetInt("Highscore", 0);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        PlayerPrefs.Save();
        score.text = "Рекорд: " + PlayerPrefs.GetInt("Highscore", 0);
    }
}
