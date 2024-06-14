using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Objetos : MonoBehaviour
{
    private bool caninteract;
    private GameObject objeto;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (caninteract && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Destroy(objeto);
            caninteract = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        caninteract = true;
        Debug.Log("pode");
        objeto = collision.gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        caninteract = false;
        Debug.Log("naopode");
    }
}
