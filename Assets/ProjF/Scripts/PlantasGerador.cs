using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlantasgGerador : MonoBehaviour
{
    public GameObject[] prefabs;
    public int ninstacecada;
    public Vector2 Spawnareamin;
    public Vector2 Spawnareamax;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {

    }

}