using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Text quantityText;
    private int quantity = 1;
    public string itemtype;

    public void IncrementQuantity()
    {
        quantity++;
        UpdateQuantityText();
    }
    public void DecrementQuantity()
    {
        quantity--;
        if (quantity <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            UpdateQuantityText();
        }
    }

    public string Getitemtype()
    {
        return itemtype;
    }
    private void UpdateQuantityText()
    {
        quantityText.text = quantity.ToString();
    }
}
