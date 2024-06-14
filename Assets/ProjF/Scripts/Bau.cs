using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bau : MonoBehaviour
{
    private Animator chestAnimator;
    public Animator coinAnimator;
    public GameObject coinObject;
    private AudioSource coinAudio;
    private bool caninteract;

    void Start()
    {
        chestAnimator = GetComponent<Animator>();
        coinAudio = GetComponent<AudioSource>();
        coinObject.SetActive(false);
    }

    private void Update()
    {
        if (caninteract && Keyboard.current.eKey.wasPressedThisFrame)
        {
            OpenChest();
        }
    }

    public void OpenChest()
    {
        chestAnimator.Play("Bau aberto");
        coinObject.SetActive(true);
        coinAnimator.Play("Moeda");
        Invoke("animamoeda", 0.1f);
        coinAudio.Play();
        Destroy(gameObject, 2f);
    }

    private void animamoeda()
    {
        coinAnimator.Play("Moeda2");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        caninteract = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        caninteract = false;
    }
}
