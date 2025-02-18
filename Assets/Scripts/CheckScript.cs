using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScript : MonoBehaviour
{
    int chechpointsNum = 0;
    int vueltas = 0;
    private GameObject[] checkPoints; // Array de cámaras

    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            uiManager = canvas.GetComponent<UIManager>();
        }

        checkPoints = new GameObject[4]; // Ajusta el tamaño según la cantidad de checkpoints esperados
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {


        if (collision.CompareTag("CheckPoint"))
        {
            if (vueltas == 1)
            {
                checkPoints[chechpointsNum] = collision.gameObject;
            }
            checkPoints[chechpointsNum].SetActive(false);
            chechpointsNum++;
            Debug.Log("Checkpoints " + chechpointsNum);

        }

        if (collision.CompareTag("Start"))
        {
            
            if (vueltas == 0 || chechpointsNum == 4)
            {
                if (vueltas > 0)
                {
                    for (int i = 0; i < checkPoints.Length; i++)
                    {
                        checkPoints[i].SetActive(true);
                    }
                }
                vueltas++;
                chechpointsNum = 0;

                if (vueltas > 1)
                {
                    if (uiManager != null)
                    {
                        uiManager.RestartTimer();
                        uiManager.SetTime(vueltas - 2);
                    }
                }
                Debug.Log("Vuelta " + vueltas);

            }
            
            if (vueltas == 4)
            {
                uiManager.SetTotalTime();
                uiManager.ActiveScore();
            }
        }
    }



    public int GetVueltas()
    {
        return vueltas;
    }

    public int GetCheckpoints()
    {
        return chechpointsNum;
    }
}
