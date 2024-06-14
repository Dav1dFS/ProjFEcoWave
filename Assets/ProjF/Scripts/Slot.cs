using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isfull[i] = false;
        }
    }

    public void dropitem()
    {
        ItemButton itemButton = GetComponentInChildren<ItemButton>();

        if (itemButton != null)
        {
            string objectType = itemButton.Getitemtype();
            Debug.Log("Tipo de objeto: " + objectType);

            string ecopontoTag = GetEcopontoTag(objectType);
            Debug.Log("Ecoponto certo: " + ecopontoTag);

            if (IsTouchingCorrectEcoponto(ecopontoTag))
            {
                string ecopontoObjectType = GetObjectTypeFromEcopontoTag(ecopontoTag);

                if (objectType == ecopontoObjectType)
                {
                    Debug.Log("Funciona Reciclado");
                    itemButton.DecrementQuantity();

                    
                    Destroy(itemButton.gameObject);

                    
                    inventory.isfull[i] = false;
                }
                else
                {
                    Debug.Log("O tipo de objeto não corresponde ao ecoponto.");
                }
            }
            else
            {
                Debug.Log("O jogador não está a colidir com o ecoponto certo para o objeto: " + objectType + ".");
            }
        }
        else
        {
            Debug.Log("Não há nenhum item nesta slot para reciclar.");
        }
    }

    private string GetEcopontoTag(string objectType)
    {
        switch (objectType)
        {
            case "Cartao":
                return "EcopontoAzul";
            case "Vidro":
                return "EcopontoVerde";
            case "Plastico":
                return "EcopontoAmarelo";
            default:
                Debug.Log("Tipo inválido: " + objectType);
                return null;
        }
    }

    private bool IsTouchingCorrectEcoponto(string ecopontoTag)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("Player não encontrado.");
            return false;
        }

        Collider2D playerCollider = player.GetComponent<Collider2D>();
        Collider2D[] ecopontoColliders = Physics2D.OverlapCircleAll(player.transform.position, 0.1f);

        foreach (Collider2D collider in ecopontoColliders)
        {
            if (collider.CompareTag(ecopontoTag) && playerCollider.IsTouching(collider))
            {
                return true;
            }
        }
        return false;
    }

    private string GetObjectTypeFromEcopontoTag(string ecopontoTag)
    {
        switch (ecopontoTag)
        {
            case "EcopontoAzul":
                return "Cartao";
            case "EcopontoVerde":
                return "Vidro";
            case "EcopontoAmarelo":
                return "Plastico";
            default:
                Debug.Log("Tag de ecoponto inválida: " + ecopontoTag);
                return null;
        }
    }
}
