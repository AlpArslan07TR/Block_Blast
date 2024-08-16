using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckForMatch()
    {
        Transform submitArea = GameObject.Find("SubmitArea").transform;
        List<Transform> cubesInSubmitArea = new List<Transform>();

        foreach (Transform child in submitArea)
        {
            cubesInSubmitArea.Add(child);
        }

        // Eþleþme kontrolü
        for (int i = 0; i < cubesInSubmitArea.Count - 2; i++)
        {
            if (cubesInSubmitArea[i].GetComponent<Renderer>().material.color ==
                cubesInSubmitArea[i + 1].GetComponent<Renderer>().material.color &&
                cubesInSubmitArea[i].GetComponent<Renderer>().material.color ==
                cubesInSubmitArea[i + 2].GetComponent<Renderer>().material.color)
            {
                // Eþleþme bulundu
                Destroy(cubesInSubmitArea[i].gameObject);
                Destroy(cubesInSubmitArea[i + 1].gameObject);
                Destroy(cubesInSubmitArea[i + 2].gameObject);
                // Diðer iþlemler
            }
        }
    }
}