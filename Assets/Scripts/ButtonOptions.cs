using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonOptions : MonoBehaviour
{
    public Button c1Btn1, c2Btn1, car1Btn1, car2Btn1;
    //public GameObject coche1Prefab, coche2Prefab;

    private bool c1Btn, c2Btn, car1Btn, car2Btn = false;
    //bool outline1, outline2, outline3, outline4; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BtnSelected(Button btnOn, Button btnOff)
    {
        btnOn.GetComponent<Outline>().enabled = true;
        btnOff.GetComponent<Outline>().enabled = false;
    }

    public void carretera1Btn()
    {
        if (!c1Btn)
        {
            c2Btn = false;
            c1Btn = true;
            BtnSelected(c1Btn1, c2Btn1);

            Debug.Log("Has seleccionado el primer circuito");
        }
    }

    public void carretera2Btn()
    {
        if (!c2Btn)
        {
            c1Btn = false;
            c2Btn = true;
            BtnSelected(c2Btn1, c1Btn1);

            Debug.Log("Has seleccionado el segundo circuito");
        }
    }
    public void coche1Btn()
    {
        if (!car1Btn)
        {
            car2Btn = false;
            car1Btn = true;
            BtnSelected(car1Btn1, car2Btn1);

            Debug.Log("Has seleccionado el primer coche");
        }
    }

    public void coche2Btn()
    {
        if (!car2Btn)
        {
            car1Btn = false;
            car2Btn = true;
            BtnSelected(car2Btn1, car1Btn1);

            Debug.Log("Has seleccionado el segndo coche");
        }
    }

    public bool Getc1Btn()
    {
        return c1Btn;
    }
    public bool Getc2Btn()
    {
        return c2Btn;
    }
    public bool Getcar1Btn()
    {
        return car1Btn;
    }
    public bool Getcar2Btn()
    {
        return car2Btn;
    }

    public void ClickStart()
    {
        if (car1Btn)
        {
            GameManager.Instance.SetCar(0);
        }else if (car2Btn)
        {
            GameManager.Instance.SetCar(1);
        }
        if (c1Btn)
        {
            SceneManager.LoadScene("PracticaScene");
        }
        else if (c2Btn)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
