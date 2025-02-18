using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int cochePrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe otro GameManager, destruye este
        }
    }

    public void SetCar(int i)
    {
        cochePrefab = i;
    }
    public int GetCar() 
    {
        return cochePrefab;
    }

}