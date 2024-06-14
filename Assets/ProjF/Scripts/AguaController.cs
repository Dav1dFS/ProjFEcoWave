using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaController : MonoBehaviour
{
    public float velagua;
    public GameObject agua2;
    public GameObject agua3;
    // Start is called before the first frame update
    void Start()
    {
        aguafrente();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void aguafrente()
    {
        agua2.SetActive(false);
        agua3.SetActive(false);
        Invoke("aguameio", 0.5f);
    }
    void aguameio()
    {
        agua2.SetActive(true);
        agua3.SetActive(false);
        Invoke("aguafrente", 0.5f);
    }
    void aguatras()
    {
        agua2.SetActive(false);
        agua3.SetActive(true);
        Invoke("aguatras", 0.5f);
    }
}
