using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChestEspecial : MonoBehaviour
{
    private bool caninteract;
    private Animator animator;
    public GameObject objetonpc;
    public NpcControl npcControl;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("BauQuest1");
    }

    // Update is called once per frame
    void Update()
    {
        if (caninteract == true)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                npcControl.missioncomplete = true;
                animator.Play("BauQuest1Open");
                objetonpc.SetActive(true);
                Invoke("destroybau", 1f);   
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        caninteract = true;
        Debug.Log("pode");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        caninteract = false;
        Debug.Log("naopode");
    }
    private void destroybau()
    {
        Destroy(gameObject);
    }
}