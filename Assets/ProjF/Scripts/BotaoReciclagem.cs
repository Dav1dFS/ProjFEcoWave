using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoReciclagem : MonoBehaviour
{
    public Slot slotScript;
    private Ecoponto ecoponto;

    void Start()
    {

    }

    public void OnButtonClick()
    {
        if (ecoponto.caninteract == true)
        {
            Debug.Log("Cliqueinoreciclar");
            slotScript.dropitem();
        }

    }
}
