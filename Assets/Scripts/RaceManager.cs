using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public Transform spawn;

    public GameObject coche1;
    public GameObject coche2;

    private GameObject coche;
    // Start is called before the first frame update
    void Start()
    {
        int cocheGuardado = GameManager.Instance.GetCar();
        Debug.Log("intCoche " +  cocheGuardado);

        if (cocheGuardado == 0)
        {
            coche = Instantiate(coche1, spawn.position, spawn.rotation);
        }else if (cocheGuardado == 1)
        {
            coche = Instantiate(coche2, spawn.position, spawn.rotation);
        }
        FindObjectOfType<UIManager>().SetCar(coche);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
