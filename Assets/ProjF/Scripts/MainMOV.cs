using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMOV : MonoBehaviour
{
    [SerializeField] float vel;
    private Animator animator;
    private bool ismoving;
    private string currentdirection;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        teclado();
    }
    void teclado()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            this.transform.Translate(0, vel * Time.deltaTime, 0);
            animator.Play("WalkC2");
            ismoving = true;
            currentdirection = "C";

        }
        else if (Keyboard.current.sKey.isPressed)
        {
            this.transform.Translate(0, -vel * Time.deltaTime, 0);
            animator.Play("WalkB2");
            ismoving = true;
            currentdirection = "B";
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            this.transform.Translate(-vel * Time.deltaTime, 0, 0);
            animator.Play("WalkE2");
            ismoving = true;
            currentdirection = "E";
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            this.transform.Translate(vel * Time.deltaTime, 0, 0);
            animator.Play("WalkD2");
            ismoving = true;
            currentdirection = "D";
        }
        else
        {
            if (ismoving)
            {
                animator.Play("Idle" + currentdirection + "2");
                ismoving = false;
            }
        }
    }
}
