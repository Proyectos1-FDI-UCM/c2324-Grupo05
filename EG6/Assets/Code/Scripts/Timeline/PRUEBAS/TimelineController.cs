using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    //reference to saved file
    [SerializeField] GameObject[] cinem�ticas; // Arreglo para almacenar las cinem�ticas
    [SerializeField] GameObject _menu;
    private int cinem�ticaActual = -1; // �ndice de la cinem�tica actual (-1 significa que ninguna est� siendo reproducida)

    void Start()
    {
        _menu.SetActive(true);
        // Desactiva todas las cinem�ticas al inicio
        foreach (GameObject cinem�tica in cinem�ticas)
        {
            cinem�tica.SetActive(false);
        }
    }

    // M�todo para iniciar una cinem�tica espec�fica
    public void IniciarCinem�tica(int �ndice)
    {
        // Si hay una cinem�tica reproduci�ndose, la detenemos
        if (cinem�ticaActual != -1)
        {
            cinem�ticas[cinem�ticaActual].SetActive(false);
        }

        // Activamos la nueva cinem�tica
        _menu.SetActive(false);
        cinem�ticaActual = �ndice;
        cinem�ticas[�ndice].SetActive(true);
    }

    // M�todo para cambiar de escena
    public void CambiarEscena()
    {
        SceneManager.LoadScene("BedroomTest");
    }
}
