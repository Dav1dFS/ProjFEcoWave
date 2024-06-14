using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BauQuest2 : MonoBehaviour
{
    private bool caninteract;
    private Animator animator;
    public Casaquest2 casaquest;
    public GameObject objetoquest2;
    // Start is called before the first frame update
    void Start()
    {
        caninteract = false;
        animator = GetComponent<Animator>();
        objetoquest2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (caninteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                casaquest.missioncomplete = true;
                objetoquest2.SetActive(true);
                animator.Play("BauQuest2Open");
                Invoke("destroybau", 1f);
            }

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
    private void destroybau()
    {
        Destroy(gameObject);
    }
}
