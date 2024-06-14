using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Casaquest2 : MonoBehaviour
{
    private bool caninteract;
    public GameObject texto;
    private Animator animator;
    [SerializeField] TMP_Text dialogtext;
    [SerializeField] List<string> dialog;
    [SerializeField] List<string> dialog2;
    [SerializeField] float veltexto;
    private int indexdialogo = 0;
    private Coroutine escrevetexto;
    private AudioSource voiceaudio;
    public bool missioncomplete;
    public TMP_Text textomissao;
    private bool dialogueComplete;
    public GameObject imagem;
    private AudioSource missionaudio;

    void Start()
    {
        caninteract = false;
        missioncomplete = false;
        texto.SetActive(false);
        voiceaudio = GetComponent<AudioSource>();
        dialogueComplete = false;
    }

    void Update()
    {
        if (caninteract)
        {
            if (Keyboard.current.zKey.wasPressedThisFrame)
            {
                if (escrevetexto != null)
                {
                    StopCoroutine(escrevetexto);
                    dialogtext.text = missioncomplete ? dialog2[indexdialogo] : dialog[indexdialogo];
                    escrevetexto = null;
                }
                else
                {
                    avancardialogo();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!dialogueComplete)
        {
            caninteract = true;
            texto.SetActive(true);
            indexdialogo = 0;
            mostradialogo();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        caninteract = false;
        texto.SetActive(false);
    }

    void mostradialogo()
    {
        if (indexdialogo < (missioncomplete ? dialog2.Count : dialog.Count))
        {
            if (escrevetexto != null)
            {
                StopCoroutine(escrevetexto);
            }
            escrevetexto = StartCoroutine(Typetext(missioncomplete ? dialog2[indexdialogo] : dialog[indexdialogo]));
        }
        else
        {
            texto.SetActive(false);
            if (missioncomplete)
            {
                dialogueComplete = true;
            }
        }
    }

    void avancardialogo()
    {
        if (indexdialogo < (missioncomplete ? dialog2.Count - 1 : dialog.Count - 1))
        {
            indexdialogo++;
            mostradialogo();
        }
        else
        {
            texto.SetActive(false);
            if (missioncomplete)
            {
                dialogueComplete = true;
                imagem.SetActive(true);
                Invoke("tiramission", 2f);
                missionaudio.Play();
            }
        }
    }

    IEnumerator Typetext(string text)
    {
        dialogtext.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogtext.text += letter;
            voiceaudio.Play();
            yield return new WaitForSeconds(veltexto);
        }
        escrevetexto = null;
    }
    private void tiramission()
    {
        imagem.SetActive(false);
    }
}
