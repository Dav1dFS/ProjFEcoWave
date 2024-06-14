using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcControl : MonoBehaviour
{
    public GameObject alvo;
    public GameObject texto;
    Vector3 diff;
    public float vel;
    private Animator animator;
    private string currentdirection;
    [SerializeField] TMP_Text dialogtext;
    [SerializeField] List<string> dialog;
    [SerializeField] List<string> dialog2; 
    [SerializeField] float veltexto;
    private int indexdialogo = 0;
    private Coroutine escrevetexto;
    private AudioSource voiceaudio;
    public bool missioncomplete;
    public TMP_Text textomissao;
    private bool caninteract;
    public GameObject imagem;
    private AudioSource missionaudio;

    void Start()
    {
        caninteract = false;
        missioncomplete = false;
        texto.SetActive(false);
        animator = GetComponent<Animator>();
        voiceaudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (vel != 0)
        {
            diff = alvo.transform.position - this.transform.position;
            diff.Normalize();
            diff = diff / vel;
            this.transform.Translate(diff);

            float absX = Mathf.Abs(diff.x);
            float absY = Mathf.Abs(diff.y);

            if (absY > absX)
            {
                if (diff.y > 0)
                {
                    animator.Play("NpcWalkC");
                    currentdirection = "C";
                }
                else
                {
                    animator.Play("NpcWalkB");
                    currentdirection = "B";
                }
            }
            else
            {
                if (diff.x > 0)
                {
                    animator.Play("NpcWalkD");
                    currentdirection = "D";

                }
                else
                {
                    animator.Play("NpcWalkE");
                    currentdirection = "E";
                }
            }
        }
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
        if (collision.gameObject == alvo)
        {
            caninteract = true;
            vel = 0;
            animator.Play("NpcIdle" + currentdirection);
            print(diff);
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
            imagem.SetActive(true);
            Invoke("tiramission", 2f);
            missionaudio.Play();
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
