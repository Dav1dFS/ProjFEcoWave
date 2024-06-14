using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dunas : MonoBehaviour
{
    public GameObject planta;
    private bool caninteract;
    // Start is called before the first frame update
    void Start()
    {
        planta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (caninteract && Keyboard.current.eKey.wasPressedThisFrame)
            {
                planta.SetActive(true);
            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        caninteract = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        caninteract = false;
    }
}
