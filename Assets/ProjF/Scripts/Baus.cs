using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Baus : MonoBehaviour
{
    public GameObject[] prefabs;
    public int ninstacecada;
    public Vector2 Spawnareamin;
    public Vector2 Spawnareamax;
    private bool caninteract;
    void Start()
    {
        foreach (GameObject prefab in prefabs)
        {
            for (int i = 0; i < ninstacecada; i++)
            {
                float randomX = UnityEngine.Random.Range(Spawnareamin.x, Spawnareamax.x);
                float randomY = UnityEngine.Random.Range(Spawnareamin.y, Spawnareamax.y);
                Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
                GameObject bauInstance = Instantiate(prefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
