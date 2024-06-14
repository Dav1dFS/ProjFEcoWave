using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao : MonoBehaviour
{
    public Animator animator;
    public bool isvisible = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void togglevisibility()
    {
        isvisible = !isvisible;
        animator.SetTrigger(isvisible ? "Show" : "Hide");
    }
}
