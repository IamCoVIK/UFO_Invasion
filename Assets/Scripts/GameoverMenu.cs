using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameoverMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text highscore;
    [SerializeField] private Animator blasterAnim;
    [SerializeField] private Blaster blaster;
    [Space]
    [SerializeField] private Game game;

    private void OnEnable()
    {
        blasterAnim.SetBool("Up", false);
        blaster.charged = false;
        score.text = "Очки: " + game.score;
        highscore.text = "Рекорд: " + PlayerPrefs.GetInt("Highscore", 0);
    }
}
