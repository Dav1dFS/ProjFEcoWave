using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    private bool caninteract;
    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        if (caninteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {

                tutorial.SetActive(true);
            }
        }
    }
    public void fechar()
    {
        tutorial.SetActive(false);
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
