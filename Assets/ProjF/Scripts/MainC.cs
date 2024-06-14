using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainC : MonoBehaviour
{
    [SerializeField] float vel;
    private Animator animator;
    private bool ismoving;
    private string currentdirection;
    private bool caninteract;
    private GameObject objeto;
    private GameObject objeto2;
    private AudioSource stepaudio;
    private AudioSource lixoaudio;
    // Start is called before the first frame update
    void Start()
    {
        stepaudio = GetComponent<AudioSource>();
        lixoaudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        caninteract = false;
        objeto = null;
    }

    // Update is called once per frame
    public void Update()
    {
        teclado();

        if (caninteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
               lixoaudio.Play();
            }
        }

        if(ismoving)
        {
            if(!stepaudio.isPlaying)
            {
                stepaudio.Play();
            }
        }
    }
    void teclado()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            this.transform.Translate(0, vel * Time.deltaTime, 0);
            animator.Play("WalkC");
            ismoving = true;
            currentdirection = "C";

        }
        else if (Keyboard.current.sKey.isPressed)
        {
            this.transform.Translate(0, -vel * Time.deltaTime, 0);
            animator.Play("WalkB");
            ismoving = true;
            currentdirection = "B";
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            this.transform.Translate(-vel * Time.deltaTime, 0, 0);
            animator.Play("WalkE");
            ismoving = true;
            currentdirection = "E";
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            this.transform.Translate(vel * Time.deltaTime, 0, 0);
            animator.Play("WalkD");
            ismoving = true;
            currentdirection = "D";
        }
        else
        {
            if (ismoving)
            {
                animator.Play("Idle" + currentdirection);
                ismoving = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            caninteract = true;
            objeto = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == objeto)
        {
            caninteract = false;
            objeto = null;
        }
    }
}
