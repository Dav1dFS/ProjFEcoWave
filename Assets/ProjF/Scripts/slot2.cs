using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class slot2 : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isfull[i] = false;
        }
    }
    public void spawnitem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Plantar>().Spawnitem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
