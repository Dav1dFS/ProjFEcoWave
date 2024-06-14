using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class DayandNightCyce : MonoBehaviour
{
    [SerializeField] private Gradient lightcolor;
    [SerializeField] private Light2D light;
    private int days;
    public int Days => days;
    private float time = 50;
    private bool canchangeday = true;

    public delegate void ondaychanged();
    public ondaychanged daychanged;
    public GameObject bauquest2;

    private void Start()
    {
        light = GetComponent<Light2D>();
    }
    private void Update()
    {
        Debug.Log("Dia atual: " + days);
        if (time > 500)
        {
            time = 0;
        }
        if ((int)time == 500 && canchangeday)
        {
            canchangeday = false;
            daychanged?.Invoke(); // Verifica se há assinantes antes de invocar
            days++;
            Debug.Log("Dia atual: " + days);
        }
        if ((int)time == 255)
            canchangeday = true;

        time += Time.deltaTime;
        light.color = lightcolor.Evaluate(time * 0.002f);
        if ((int)time > 250 && (int)time < 400)
        {
            bauquest2.SetActive(true);
        }
    }
    
}
