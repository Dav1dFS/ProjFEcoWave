using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingText : MonoBehaviour
{
    public float veltexto;
    public GameObject texto1;
    public GameObject texto2;
    public GameObject texto3;
    // Start is called before the first frame update
    void Start()
    {
        textoinicio();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void textoinicio()
    {
        texto1.SetActive(true);
        texto2.SetActive(false);
        texto3.SetActive(false);
        Invoke("textomeio", 0.5f);
    }
    void textomeio()
    {
        texto1.SetActive(false);
        texto2.SetActive(true);
        texto3.SetActive(false);
        Invoke("textofim", 0.5f);
    }
    void textofim()
    {
        texto2.SetActive(false);
        texto3.SetActive(true);
        Invoke("textoinicio", 0.5f);
    }
}