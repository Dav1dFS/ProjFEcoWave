/*using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LivroTutorial : MonoBehaviour
{
    private bool caninteract;
    public GameObject folhatutorial;
    // Start is called before the first frame update
    void Start()
    {
        folhatutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (caninteract && Keyboard.current.eKey.wasPressedThisFrame)
        {
            folhatutorial.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            caninteract = true;
        }
    }
    public void fechatutorial()
    {
        folhatutorial.SetActive(false);
    }
}
*/