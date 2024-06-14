using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class lixo : MonoBehaviour
{
    public GameObject[] prefabs;
    public int ninstacecada;
    public Vector2 Spawnareamin;
    public Vector2 Spawnareamax;

    void Start()
    {
        foreach (GameObject prefab in prefabs)
        {
            for (int i = 0; i < ninstacecada; i++)
            {
                float randomX = Random.Range(Spawnareamin.x, Spawnareamax.x);
                float randomY = Random.Range(Spawnareamin.y, Spawnareamax.y);
                Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
                Instantiate(prefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    void Update()
    {

    }
}
