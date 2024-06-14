using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plantar : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Spawnitem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 1);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
