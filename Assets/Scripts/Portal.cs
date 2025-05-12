using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private float greenProb;
    [SerializeField] private float redProb;
    [SerializeField] private float blueProb;
    [Space]
    [SerializeField] private GameObject greenUFO;
    [SerializeField] private GameObject redUFO;
    [SerializeField] private GameObject blueUFO;
    [Space]
    [SerializeField] private PortalSounds sound;

    public float startSpawnRate;
    private float spawnRate;
    private float timer;

    private List<GameObject> ufos = new List<GameObject>();
    private Game game;

    private void SpawnUFO()
    {
        float i = Random.Range(0, blueProb + redProb + greenProb);
        if (i <= greenProb)
        {
            ufos.Add(Instantiate(greenUFO));
        }
        else if (i > greenProb && i <= redProb + greenProb)
        {
            ufos.Add(Instantiate(redUFO));
        }
        else if (i > redProb + greenProb && i <= blueProb + redProb + greenProb)
        {
            ufos.Add(Instantiate(blueUFO));
        }
        else
        {
            ufos.Add(Instantiate(greenUFO));
        }
        ufos[ufos.Count - 1].transform.parent = transform;
        ufos[ufos.Count - 1].transform.rotation = transform.rotation * Quaternion.Euler(GetRandomAngle());
        ufos[ufos.Count - 1].transform.position = transform.position + transform.forward * 0.1f + GetRandomDeviation();
        sound.SpawnedUFO();
    }

    public void DespawnUFO()
    {
        foreach (GameObject ufo in ufos)
        {
            Destroy(ufo);
        }
    }

    private void MultiSpawn()
    {
        float i = Random.value;
        if (i <= 0.4f)
        {
            float j = Random.value;
            if (j > 0.4f)
            {
                SpawnUFO();
            }
            else
            {
                SpawnUFO();
                SpawnUFO();
            }
        }
    }

    private Vector3 GetRandomDeviation()
    {
        float right = Random.Range(-1f, 1f) * 0.14f;
        float forward = Random.Range(-1f, 1f) * 0.14f;
        Vector3 deviation = transform.right * right + transform.forward * forward;
        return deviation;
    }

    private Vector3 GetRandomAngle()
    {
        float angle1 = Random.Range(-15f, 15f);
        float angle2 = Random.Range(-15f, 15f);
        return new Vector3(angle1, angle2);
    }

    private void RiseRate()
    {
        if (game.score >= 1000)
        {
            spawnRate = startSpawnRate * 0.05f;
        }
        else if (game.score >= 500)
        {
            spawnRate = startSpawnRate * 0.1f;
        }
        else if (game.score >= 200)
        {
            spawnRate = startSpawnRate * 0.2f;
        }
        else if (game.score >= 100)
        {
            spawnRate = startSpawnRate * 0.3f;
        }
        else if (game.score >= 50)
        {
            spawnRate = startSpawnRate * 0.4f;
        }
        else if (game.score >= 20)
        {
            spawnRate = startSpawnRate * 0.5f;
        }
        else if(game.score >= 10)
        {
            spawnRate = startSpawnRate * 0.75f;
        }
    }

    private void Start()
    {
        DespawnUFO();
        game = GameObject.Find("Game").GetComponent<Game>();
        spawnRate = startSpawnRate;
        timer = spawnRate;
        game.Health();
    }

    private void FixedUpdate()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            SpawnUFO();
            MultiSpawn();
            RiseRate();
            timer = spawnRate;
        }
    }

    private void OnDestroy()
    {
        DespawnUFO();
        spawnRate = startSpawnRate;
        foreach (Transform i in GameObject.Find("Trackables").GetComponentsInChildren<Transform>())
        {
            i.gameObject.layer = 0;
        }
    }
}
