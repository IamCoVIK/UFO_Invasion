using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private float Lifetime;
    [SerializeField] private float Speed;
    public int Value;
    [Space]
    [SerializeField] private GameObject SpawnEffect;
    [SerializeField] private GameObject DeathEffect;
    [SerializeField] private Animator animator;
    [SerializeField] private UFOSounds sounds;

    private bool escaped = false;

    private Game game;
    private Vector3 move_vector;

    public void Config()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        move_vector = transform.forward * Speed;
    }

    public void UpdateMove()
    {
        move_vector = transform.forward * Speed;
    }

    private void SpawnAnim()
    {
        GameObject spawnPart = Instantiate(SpawnEffect, transform.parent);
        spawnPart.transform.position = transform.position;
        spawnPart.transform.rotation = transform.rotation;
    }

    private void DeathAnim()
    {
        GameObject spawnPart = Instantiate(DeathEffect, transform.parent);
        spawnPart.transform.position = transform.position;
    }

    public void Move()
    {
        transform.transform.position += move_vector * Time.deltaTime;
        Lifetime -= Time.deltaTime;
    }

    public void EscapeCheck()
    {
        if (Lifetime <= 0 && !escaped)
        {
            game.AddMissed(Escape());
        }
    }

    private int Escape()
    {
        escaped = true;
        animator.SetTrigger("Escape");
        sounds.EscapeSound();
        Destroy(gameObject, 0.5f);
        return Value;
    }

    private int Death()
    {
        DeathAnim();
        Destroy(gameObject);
        return Value;
    }

    public int Killed()
    {
        if (escaped)
        {
            return game.RemoveMissed(0);
        }
        return game.RemoveMissed(Death());
    }    

    private void Start()
    {
        Config();
        SpawnAnim();
    }

    /*private void FixedUpdate()
    {
        Move();
        EscapeCheck();
    }*/
}
