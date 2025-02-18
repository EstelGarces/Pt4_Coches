using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tiempoText;
    public TextMeshProUGUI velocidadText;

    public TextMeshProUGUI[] vueltas; // Array de cámaras
    private float[] tiempos; // Array de cámaras


    public GameObject finalScore;

    //public TextMeshProUGUI vuelta1;
    //public TextMeshProUGUI vuelta2;
    //public TextMeshProUGUI vuelta3;

    private PrometeoCarController coche;
    private CheckScript timeScript;

    private float tiempoInicio = 0f;
    private float tiempoTotal = 0f;
    private float tiempoActual = 0f;

    // Start is called before the first frame update
    public void SetCar(GameObject cocheInstanciado)
    {
        coche = cocheInstanciado.GetComponent<PrometeoCarController>();
        timeScript = cocheInstanciado.GetComponent<CheckScript>();
        tiempos = new float[vueltas.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (timeScript.GetVueltas() < 1 || timeScript.GetVueltas() == 4)
        {
            tiempoText.text = "Tiempo: 0s";
        }
        else
        {
            if (tiempoInicio == 0)
            {
                tiempoInicio = Time.time;
            }
            tiempoActual = Time.time - tiempoInicio;
            tiempoActual = Mathf.Round(tiempoActual * 100f) / 100f;

            tiempoText.text = "Tiempo: " + Mathf.Floor(tiempoActual) + "s";
        }
        velocidadText.text = coche.CarSpeedUI();
    }

    public void SetTime(int i)
    {
        if (i < vueltas.Length)
        {
            vueltas[i].text = tiempoActual + "s";
            tiempos[i] = tiempoActual;
            vueltas[i].ForceMeshUpdate(); // Forzar actualización del texto en pantalla

            Debug.Log("tiempo vuelta " + vueltas[i].text);
        }
    }

    public void SetTotalTime()
    {
        for (int i = 0; i < vueltas.Length - 1; i++) 
        {
            tiempoTotal += tiempos[i];
        }
        vueltas[vueltas.Length - 1].text = tiempoTotal  + "s";
        vueltas[vueltas.Length - 1].ForceMeshUpdate();
    }
    public void RestartTimer()
    {
        tiempoInicio = 0f;
    }
    public void ClickSeguir()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ActiveScore()
    {
        finalScore.SetActive(true);
    }
}
