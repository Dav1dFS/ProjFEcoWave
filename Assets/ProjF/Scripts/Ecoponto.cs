using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ecoponto : MonoBehaviour
{
    public bool caninteract;
    // Start is called before the first frame update
    void Start()
    {
        caninteract = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            caninteract = true;
        }    
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            caninteract = false;
        }
    }
}
