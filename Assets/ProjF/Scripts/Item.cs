using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    private bool canInteract;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if (canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("clicou");

                for (int i = 0; i < 4; i++)
                {
                    ItemButton existingItemButton = inventory.slots[i].GetComponentInChildren<ItemButton>();
                    if (existingItemButton != null && existingItemButton.gameObject.name == itemButton.name)
                    {
                        existingItemButton.IncrementQuantity();
                        Destroy(gameObject);
                        canInteract = false;
                        return;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (inventory.isfull[i] == false)
                    {
                        inventory.isfull[i] = true;
                        GameObject newItemButton = Instantiate(itemButton, inventory.slots[i].transform, false);
                        newItemButton.name = itemButton.name;
                        Destroy(gameObject);
                        canInteract = false;
                        break;
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            Debug.Log("Colidiu");
        }
    }
}
