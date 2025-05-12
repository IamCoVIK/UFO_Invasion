using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private Animator blasterAnim;
    [SerializeField] private GameObject Hitmark;
    [SerializeField] private Blaster blaster;

    public void RestartGame()
    {
        blasterAnim.SetBool("Up", false);
        blaster.charged = false;
        game.Restart();
        Hitmark.SetActive(false);
    }
}
