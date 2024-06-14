using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BotaoLoja : MonoBehaviour
{
    public GameObject Loja;
    public GameObject fonte;
    public Vector2 Spawnareamin;
    public Vector2 Spawnareamax;

    public void OnButtonClick()
    {
        Loja.SetActive(true);
    }

    // Método para fechar a loja
    public void FecharLoja()
    {
        Loja.SetActive(false);
    }
    public void comprarfonte()
    {
        if (fonte != null)
        {
            float randomX = UnityEngine.Random.Range(Spawnareamin.x, Spawnareamax.x);
            float randomY = UnityEngine.Random.Range(Spawnareamin.y, Spawnareamax.y);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
            GameObject fonteInstance = Instantiate(fonte, spawnPosition, Quaternion.identity);
            Debug.Log(randomX + randomY);
        }
        else
        {
            Debug.LogError("Prefab 'fonte' não atribuído ao botão de loja.");
        }
    }
}
