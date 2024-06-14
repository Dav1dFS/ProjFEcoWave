using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaControl : MonoBehaviour
{
    public float velagua;
    public GameObject agua;
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
        agua.SetActive(true);
        agua2.SetActive(false);
        agua3.SetActive(false);
        Invoke("aguameio", velagua);
    }
    void aguameio()
    {
        agua.SetActive (false);
        agua2.SetActive(true);
        agua3.SetActive(false);
        Invoke("aguatras", velagua);
    }
    void aguatras()
    {
        agua2.SetActive(false);
        agua3.SetActive(true);
        Invoke("aguafrente", velagua);
    }
}
